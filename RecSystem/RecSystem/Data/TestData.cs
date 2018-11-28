using RecSystem.Data;
using RecSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RecSystem.Data
{
    public class TestData
    {
        public static void CreateTestData(ApplicationDbContext _db)
        {
            /*
             * Внимание!!!
             * Перед заполнением тестовыми данными таблицы:
             * Users, Items и Rating будут очищены 
             */

            _db.Ratings.RemoveRange(_db.Ratings);
            _db.SaveChanges();

            _db.Users.RemoveRange(_db.Users);
            _db.SaveChanges();

            _db.Items.RemoveRange(_db.Items);
            _db.SaveChanges();

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
                new Item() {MovieTitle = "The Night Listener"}
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
       
    }
}