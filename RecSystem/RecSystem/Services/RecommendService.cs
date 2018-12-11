using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecSystem.Services
{
    /* 
     * Класс вычисления рекомендаций 
     * для текущего пользователя 
     * на основании его оценок и оценок других пользователей
     */

    public class RecommendService
    {
        public ApplicationDbContext _db;

        public RecommendService(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<int> GetListRecommendIdItemForUserId(string CustomerId)
        {
            List<int> recommendList = new List<int>();
            var item = _db.Ratings.Where(x => x.CustomerId == CustomerId).FirstOrDefault();
            if (item == null) return recommendList;

            Dictionary<string, Dictionary<int, int>> dictRating =
                      _db.Ratings.GroupBy(x => x.CustomerId)
                                 .ToDictionary(y => y.Key, z => z.ToDictionary(k => k.ItemID, m => m.Score));

            try
            {
                recommendList = GetRecomendations(dictRating, CustomerId);
            }
            catch { }

            return recommendList;
        }

        public List<int> GetListRecommendIdItemForUserIdBD(string CustomerId)
        {
            //_db.Database.SetCommandTimeout(200);
            Dictionary<string, Dictionary<int, int>> dictRating =
                      _db.Ratings.GroupBy(x => x.CustomerId)
                                 .ToDictionary(y => y.Key, z => z.ToDictionary(k => k.ItemID, m => m.Score));

            return GetRecomendations(dictRating, CustomerId);
        }


        // Версия со словарем
        private static List<int> GetRecomendations(Dictionary<string, Dictionary<int, int>> dict, string CustomerId, double thresholdScore = 4.5)
        {
            Dictionary<int, double> sumScore = new Dictionary<int, double>();
            Dictionary<int, double> sumR = new Dictionary<int, double>();

            Dictionary<int, double> recomendationsDict = new Dictionary<int, double>();
            List<int> recomendationsList = new List<int>();

            foreach (var other in dict.Keys)
            {
                if (other == CustomerId)
                {
                    continue;
                }
                double r = CoefR(dict, other, CustomerId);

                if (r > 0)
                {
                    foreach (var item in dict[other].Keys)
                    {
                        if (!dict[CustomerId].ContainsKey(item))
                        {
                            if (sumR.ContainsKey(item))
                            {
                                sumR[item] = sumR[item] + r;
                                sumScore[item] = sumScore[item] + r * dict[other][item];
                            }
                            else
                            {
                                sumR[item] = r;
                                sumScore[item] = r * dict[other][item];
                            }
                        }
                    }
                }
            }

            foreach (var item in sumR.Keys)
            {
                var score = (sumScore[item] / sumR[item]);
                if (score > thresholdScore)
                {
                    recomendationsDict.Add(item, score);
                }
            }

            foreach (var item in recomendationsDict.OrderByDescending(x => x.Value))
            {
                recomendationsList.Add(item.Key);
            }

            return recomendationsList;
        }

        private static double CoefR(Dictionary<string, Dictionary<int, int>> dict, string CustomerId1, string CustomerId2)
        {
            List<int> rating1 = new List<int>();
            List<int> rating2 = new List<int>();

            double sumRating1 = 0;
            double sumRating2 = 0;
            double sumMultiRating = 0;
            double sumSqRating1 = 0;
            double sumSqRating2 = 0;
            double n = 0;

            foreach (var item1 in dict[CustomerId1].Keys)
            {
                foreach (var item2 in dict[CustomerId2].Keys)
                {
                    if (item1 == item2)
                    {
                        sumRating1 = sumRating1 + dict[CustomerId1][item1];
                        sumRating2 = sumRating2 + dict[CustomerId2][item2];
                        sumMultiRating = sumMultiRating + dict[CustomerId1][item1] * dict[CustomerId2][item2];
                        sumSqRating1 = sumSqRating1 + Math.Pow(dict[CustomerId1][item1], 2);
                        sumSqRating2 = sumSqRating2 + Math.Pow(dict[CustomerId2][item2], 2);
                        n = n + 1;
                        break;
                    }
                }
            }

            if (n < 4)
            {
                return 0;
            }

            double Cxy = sumMultiRating - (sumRating1 * sumRating2) / n;
            double Cx = sumSqRating1 - Math.Pow(sumRating1, 2) / n;
            double Cy = sumSqRating2 - Math.Pow(sumRating2, 2) / n;

            double R = Cxy / (Math.Sqrt(Cx * Cy));

            double m = Math.Sqrt((1 - Math.Pow(R, 2)) / (n - 2));
            if ((R / m) < 2)
            {
                return 0;
            }

            return R;
        }

        // Версия без словаря
        public List<int> GetRecomendationsWithoutDict(string CustomerId, double thresholdScore = 4.5)
        {
            Dictionary<int, double> sumScore = new Dictionary<int, double>();
            Dictionary<int, double> sumR = new Dictionary<int, double>();

            Dictionary<int, double> recomendationsDict = new Dictionary<int, double>();
            List<int> recomendationsList = new List<int>();

            IQueryable<Models.Rating> personDB = _db.Ratings.Where(x => x.CustomerId == CustomerId);
            var customerDB = _db.Customers.Select(x => x.Id);

            foreach (var other in customerDB)
            {
                if (other == CustomerId)
                {
                    continue;
                }

                IQueryable<Models.Rating> otherDB = _db.Ratings.Where(x => x.CustomerId == other);

                double r = CoefRWithoutDict(other, CustomerId, personDB, otherDB);

                if (r > 0)
                {
                    foreach (var item in otherDB.Select(x => x.ItemID))
                    {
                        if (!personDB.Select(x => x.ItemID).Contains(item))
                        {
                            if (sumR.ContainsKey(item))
                            {
                                sumR[item] = sumR[item] + r;
                                sumScore[item] = sumScore[item] + r * otherDB
                                                                      .Where(x => x.ItemID == item)
                                                                      .Select(x => x.Score)
                                                                      .First();
                            }
                            else
                            {
                                sumR[item] = r;
                                sumScore[item] = r * otherDB
                                                     .Where(x => x.ItemID == item)
                                                     .Select(x => x.Score)
                                                     .First();
                            }
                        }
                    }
                }
            }

            foreach (var item in sumR.Keys)
            {
                var score = (sumScore[item] / sumR[item]);
                if (score > thresholdScore)
                {
                    recomendationsDict.Add(item, score);
                }
            }


            foreach (var item in recomendationsDict.OrderByDescending(x => x.Value))
            {
                recomendationsList.Add(item.Key);
            }

            return recomendationsList;
        }

        private static double CoefRWithoutDict(string CustomerId1, string CustomerId2, IQueryable<Models.Rating> personDB, IQueryable<Models.Rating> otherDB)
        {
            List<int> rating1 = new List<int>();
            List<int> rating2 = new List<int>();

            double sumRating1 = 0;
            double sumRating2 = 0;
            double sumMultiRating = 0;
            double sumSqRating1 = 0;
            double sumSqRating2 = 0;
            double n = 0;

            foreach (var item1 in personDB.Select(x => x.ItemID))
            {
                foreach (var item2 in otherDB.Select(x => x.ItemID))
                {
                    if (item1 == item2)
                    {
                        sumRating1 = sumRating1 + personDB.Where(x => x.ItemID == item1).Select(x => x.Score).First();
                        sumRating2 = sumRating2 + otherDB.Where(x => x.ItemID == item2).Select(x => x.Score).First();
                        sumMultiRating = sumMultiRating + personDB.Where(x => x.ItemID == item1).Select(x => x.Score).First()
                                                        * otherDB.Where(x => x.ItemID == item2).Select(x => x.Score).First();
                        sumSqRating1 = sumSqRating1 + Math.Pow(personDB.Where(x => x.ItemID == item1).Select(x => x.Score).First(), 2);
                        sumSqRating2 = sumSqRating2 + Math.Pow(otherDB.Where(x => x.ItemID == item2).Select(x => x.Score).First(), 2);
                        n = n + 1;
                        break;
                    }
                }
            }

            double Cxy = sumMultiRating - (sumRating1 * sumRating2) / n;
            double Cx = sumSqRating1 - Math.Pow(sumRating1, 2) / n;
            double Cy = sumSqRating2 - Math.Pow(sumRating2, 2) / n;

            double R = Cxy / (Math.Sqrt(Cx * Cy));

            return R;
        }
    }
}
