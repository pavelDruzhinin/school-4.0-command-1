using Microsoft.AspNetCore.Mvc;
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
            Dictionary<string, Dictionary<int, int>> dictRating = 
                      _db.Ratings.GroupBy(x => x.CustomerId)
                                 .ToDictionary(y => y.Key, z => z.ToDictionary(k => k.ItemID, m => m.Score));

            return GetRecomendations(dictRating, CustomerId);
        }

        private static List<int> GetRecomendations(Dictionary<string, Dictionary<int, int>> dict, string CustomerId)
        {
            //В словарях: sumScore,sumR,recomendationsDict,recomendationsList 
            //тип "string" нужно переделать в "int" т.к. будем использовать id сериала

            /*добавить код*/

            return new List<int>();
        }

        private static double CoefR(Dictionary<string, Dictionary<int, int>> dict, string CustomerId1, string CustomerId2)
        {
            /*добавить код*/

            return 0.5;
        }

    }
}
