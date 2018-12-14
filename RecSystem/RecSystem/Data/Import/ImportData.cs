using Microsoft.EntityFrameworkCore;
using RecSystem.Data;
using RecSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace RecSystem.Data.Import
{
    public class ImportData
    {
        /// <summary>
        /// Метод CreateTestData()
        /// создает небольшой тестовый набор данных
        /// </summary>
        public static void CreateTestData(ApplicationDbContext _db)
        {
            RemoveTable(_db);

            List<Customer> CustomersList = new List<Customer>
            {
                new Customer() {Id = "ID-Lisa Rose"},
                new Customer() {Id = "ID-Gene Seymour"},
                new Customer() {Id = "ID-Michael Phillips"},
                new Customer() {Id = "ID-Claudia Puig"},
                new Customer() {Id = "ID-Mick LaSalle"},
                new Customer() {Id = "ID-Jack Matthews"},
                new Customer() {Id = "ID-Toby"}
            };
            _db.AddRange(CustomersList);

            List<Item> ItemsList = new List<Item>
            {
                new Item() {MovieTitle = "Lady in the Water"},
                new Item() {MovieTitle = "Snakes on a Plane"},
                new Item() {MovieTitle = "Just My Luck"},
                new Item() {MovieTitle = "Superman Returns"},
                new Item() {MovieTitle = "You, Me and Dupree"},
                new Item() {MovieTitle = "The Night Listener"},
                new Item() {MovieTitle = "Lady"},
                new Item() {MovieTitle = "Plane"},
                new Item() {MovieTitle = "Luck"},
                new Item() {MovieTitle = "Superman"},
                new Item() {MovieTitle = "You"}
            };
            _db.AddRange(ItemsList);
            _db.SaveChanges();

            List<Rating> RatingsList = new List<Rating>
            {
                new Rating() {CustomerId = "ID-Lisa Rose", ItemID = _db.Items.Where(x=>x.MovieTitle == "Lady in the Water").FirstOrDefault().ID, Score = 5},
                new Rating() {CustomerId = "ID-Lisa Rose", ItemID = _db.Items.Where(x=>x.MovieTitle == "Snakes on a Plane").FirstOrDefault().ID, Score = 7},
                new Rating() {CustomerId = "ID-Lisa Rose", ItemID = _db.Items.Where(x=>x.MovieTitle == "Just My Luck").FirstOrDefault().ID, Score = 6},
                new Rating() {CustomerId = "ID-Lisa Rose", ItemID = _db.Items.Where(x=>x.MovieTitle == "Superman Returns").FirstOrDefault().ID, Score = 7},
                new Rating() {CustomerId = "ID-Lisa Rose", ItemID = _db.Items.Where(x=>x.MovieTitle == "You, Me and Dupree").FirstOrDefault().ID, Score = 5},
                new Rating() {CustomerId = "ID-Lisa Rose", ItemID = _db.Items.Where(x=>x.MovieTitle == "The Night Listener").FirstOrDefault().ID, Score = 6},

                new Rating() {CustomerId = "ID-Gene Seymour", ItemID = _db.Items.Where(x=>x.MovieTitle == "Lady in the Water").FirstOrDefault().ID, Score = 6},
                new Rating() {CustomerId = "ID-Gene Seymour", ItemID = _db.Items.Where(x=>x.MovieTitle == "Snakes on a Plane").FirstOrDefault().ID, Score = 7},
                new Rating() {CustomerId = "ID-Gene Seymour", ItemID = _db.Items.Where(x=>x.MovieTitle == "Just My Luck").FirstOrDefault().ID, Score = 3},
                new Rating() {CustomerId = "ID-Gene Seymour", ItemID = _db.Items.Where(x=>x.MovieTitle == "Superman Returns").FirstOrDefault().ID, Score = 10},
                new Rating() {CustomerId = "ID-Gene Seymour", ItemID = _db.Items.Where(x=>x.MovieTitle == "You, Me and Dupree").FirstOrDefault().ID, Score = 7},
                new Rating() {CustomerId = "ID-Gene Seymour", ItemID = _db.Items.Where(x=>x.MovieTitle == "The Night Listener").FirstOrDefault().ID, Score = 6},

                new Rating() {CustomerId = "ID-Michael Phillips", ItemID = _db.Items.Where(x=>x.MovieTitle == "Lady in the Water").FirstOrDefault().ID, Score = 5},
                new Rating() {CustomerId = "ID-Michael Phillips", ItemID = _db.Items.Where(x=>x.MovieTitle == "Snakes on a Plane").FirstOrDefault().ID, Score = 6},
                new Rating() {CustomerId = "ID-Michael Phillips", ItemID = _db.Items.Where(x=>x.MovieTitle == "Superman Returns").FirstOrDefault().ID, Score = 7},
                new Rating() {CustomerId = "ID-Michael Phillips", ItemID = _db.Items.Where(x=>x.MovieTitle == "The Night Listener").FirstOrDefault().ID, Score = 8},

                new Rating() {CustomerId = "ID-Claudia Puig", ItemID = _db.Items.Where(x=>x.MovieTitle == "Just My Luck").FirstOrDefault().ID, Score = 6},
                new Rating() {CustomerId = "ID-Claudia Puig", ItemID = _db.Items.Where(x=>x.MovieTitle == "Snakes on a Plane").FirstOrDefault().ID, Score = 7},
                new Rating() {CustomerId = "ID-Claudia Puig", ItemID = _db.Items.Where(x=>x.MovieTitle == "Superman Returns").FirstOrDefault().ID, Score = 8},
                new Rating() {CustomerId = "ID-Claudia Puig", ItemID = _db.Items.Where(x=>x.MovieTitle == "The Night Listener").FirstOrDefault().ID, Score = 9},
                new Rating() {CustomerId = "ID-Claudia Puig", ItemID = _db.Items.Where(x=>x.MovieTitle == "You, Me and Dupree").FirstOrDefault().ID, Score = 5},

                new Rating() {CustomerId = "ID-Mick LaSalle", ItemID = _db.Items.Where(x=>x.MovieTitle == "Lady in the Water").FirstOrDefault().ID, Score = 6},
                new Rating() {CustomerId = "ID-Mick LaSalle", ItemID = _db.Items.Where(x=>x.MovieTitle == "Snakes on a Plane").FirstOrDefault().ID, Score = 8},
                new Rating() {CustomerId = "ID-Mick LaSalle", ItemID = _db.Items.Where(x=>x.MovieTitle == "Superman Returns").FirstOrDefault().ID, Score = 6},
                new Rating() {CustomerId = "ID-Mick LaSalle", ItemID = _db.Items.Where(x=>x.MovieTitle == "The Night Listener").FirstOrDefault().ID, Score = 6},
                new Rating() {CustomerId = "ID-Mick LaSalle", ItemID = _db.Items.Where(x=>x.MovieTitle == "You, Me and Dupree").FirstOrDefault().ID, Score = 4},
                new Rating() {CustomerId = "ID-Mick LaSalle", ItemID = _db.Items.Where(x=>x.MovieTitle == "Just My Luck").FirstOrDefault().ID, Score = 4},

                new Rating() {CustomerId = "ID-Jack Matthews", ItemID = _db.Items.Where(x=>x.MovieTitle == "Lady in the Water").FirstOrDefault().ID, Score = 6},
                new Rating() {CustomerId = "ID-Jack Matthews", ItemID = _db.Items.Where(x=>x.MovieTitle == "Snakes on a Plane").FirstOrDefault().ID, Score = 8},
                new Rating() {CustomerId = "ID-Jack Matthews", ItemID = _db.Items.Where(x=>x.MovieTitle == "Superman Returns").FirstOrDefault().ID, Score = 10},
                new Rating() {CustomerId = "ID-Jack Matthews", ItemID = _db.Items.Where(x=>x.MovieTitle == "The Night Listener").FirstOrDefault().ID, Score = 6},
                new Rating() {CustomerId = "ID-Jack Matthews", ItemID = _db.Items.Where(x=>x.MovieTitle == "You, Me and Dupree").FirstOrDefault().ID, Score = 7},

                new Rating() {CustomerId = "ID-Toby", ItemID = _db.Items.Where(x=>x.MovieTitle == "Snakes on a Plane").FirstOrDefault().ID, Score = 9},
                new Rating() {CustomerId = "ID-Toby", ItemID = _db.Items.Where(x=>x.MovieTitle == "Superman Returns").FirstOrDefault().ID, Score = 8},
                new Rating() {CustomerId = "ID-Toby", ItemID = _db.Items.Where(x=>x.MovieTitle == "You, Me and Dupree").FirstOrDefault().ID, Score = 2}
            };
            _db.AddRange(RatingsList);
            _db.SaveChanges();
        }

        /// <summary>
        /// Метод ImportDataFromCSV()
        /// импортирует в БД данные, загруженные 
        /// с сайта https://grouplens.org/datasets/movielens/
        /// 610 users, 9742 movies, 100 836 rating 
        /// </summary>
        public static void ImportDataFromCSV(ApplicationDbContext _db)
        {
            RemoveTable(_db);

            string path_movies = @"'C:\Users\olga\source\School\school-4.0-command-1\RecSystem\RecSystem\Data\Import\movies.csv'";
            string path_ratings = @"'C:\Users\olga\source\School\school-4.0-command-1\RecSystem\RecSystem\Data\Import\ratings.csv'";

            var sql_movies_com = $@"IF (OBJECT_ID('tempdb..#csv_temp') IS NOT NULL) DROP TABLE #csv_temp;
                                            CREATE TABLE #csv_temp (
	                                        movieId int,
	                                        title nvarchar(max),
	                                        genres nvarchar(max)
                                            );
                                            BULK INSERT #csv_temp
                                            FROM {path_movies}
                                            WITH (fieldterminator = ',', rowterminator = '\n', FIRSTROW = 2);
                                            SET IDENTITY_INSERT [dbo].Items ON;
                                            INSERT INTO dbo.Items (ID,MovieTitle,ReleaseDate,VideoReleaseDate,Url)
                                            SELECT movieId, title, null, null, null
                                            FROM #csv_temp;
                                            SET IDENTITY_INSERT dbo.Items OFF;";

            var sql_ratings_com = $@"IF (OBJECT_ID('tempdb..#csv_temp') IS NOT NULL) DROP TABLE #csv_temp;
                                            CREATE TABLE #csv_temp (
	                                        userId int,
	                                        movieId int, 
	                                        rating numeric,
	                                        timestamp nvarchar(max)
                                            );
                                            BULK INSERT #csv_temp
                                            FROM {path_ratings}
                                            WITH (fieldterminator = ',', rowterminator = '\n', FIRSTROW = 2);
                                            INSERT INTO dbo.AspNetUsers (Id, EmailConfirmed,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnabled,AccessFailedCount,Discriminator)
                                            SELECT CONVERT(varchar(450), tm.userId), 0,0,0,0,0,'Customer'
                                            FROM (select distinct userId from #csv_temp) as tm;
                                            INSERT INTO dbo.Ratings (Score, ItemID, CustomerId)
                                            SELECT rating, movieId, CONVERT(varchar(450), userId)
                                            FROM #csv_temp;";

            _db.Database.ExecuteSqlCommand(sql_movies_com);
            _db.Database.ExecuteSqlCommand(sql_ratings_com);
        }

        public static void RemoveTable(ApplicationDbContext _db)
        {
            _db.Ratings.RemoveRange(_db.Ratings);
            _db.SaveChanges();

            _db.Users.RemoveRange(_db.Users);
            _db.SaveChanges();

            _db.Items.RemoveRange(_db.Items);
            _db.SaveChanges();
        }
    }
}