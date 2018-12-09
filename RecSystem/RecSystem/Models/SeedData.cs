using FileHelpers;
using RecSystem.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using RecSystem.Data;

namespace RecSystem.Models
{
    
    public class SeedData
      
    {
        private readonly ApplicationDbContext _context;

        public SeedData(ApplicationDbContext context)
        {
            _context = context;
        }
    
        
        public void SeedGenre()
        {
            
            var engine = new FileHelperEngine<GenreTable>();
            var records = engine.ReadFile("genre", 'r');

            foreach (var record in records)
            {
                Genre item = new Genre();
                {
                item.Name = record.name;                
                }
            _context.Genres.Add(item);
                
            }
            _context.SaveChanges();

        }

        
        public void SeedFilms()
        {
            var  engine = new FileHelperEngine<ItemTable>();
            var filmsStr = engine.ReadFile("u.item",'r');
            foreach (var str in filmsStr)
            {
                List<int> value = new List<int>() {str.Unknown, str.Action, str.Adventure, str.Animation, str.Children, str.Comedy, str.Crime,
                    str.Documentary, str.Drama, str.Fantasy, str.FilmNoir, str.Horror, str.Musical, str.Mystery,
                    str.Romancepublic, str.SciFi, str.Thriller, str.War, str.Western };

                Item item = new Item();
                {
                    //item.ID = str.id;
                    item.MovieTitle = str.title;
                    item.Url = str.IMDb_URL;
                    if (DateTime.TryParse(str.releaseDate, out var release))
                    {
                        item.ReleaseDate = release;
                    }
                    if (DateTime.TryParse(str.videoReleaseDate, out var videoRelease))
                    {
                        item.VideoReleaseDate = videoRelease;
                    }
                    _context.Items.Add(item);
                    _context.SaveChanges();

                    int i = 0;
                    while( i != 19)
                    {
                        if (value[i] == 1)
                       
                        {
                            ItemGenres itemg = new ItemGenres();
                            {
                               
                                itemg.GenreID = i+1;
                                itemg.ItemID = str.id;
                            }
                            _context.ItemGenres.Add(itemg);
                        }
                        i++;
                                           
                    }
                    
                }
            
                
        _context.SaveChanges();
        }
        
        }
    }

}

    [IgnoreEmptyLines]
    [DelimitedRecord(",")]
    public class GenreTable
    {
        public int id;
        public string name;
    }
    [IgnoreEmptyLines]
    [DelimitedRecord("|")]
    public class ItemTable
    {
        public int id;
        public string title;
        public string releaseDate;
        public string videoReleaseDate;
        public string IMDb_URL;
        public int Unknown;
        public int Action;
        public int Adventure;
        public int Animation;
        public int Children;
        public int Comedy;
        public int Crime;
        public int Documentary;
        public int Drama;
        public int Fantasy;
        public int FilmNoir;
        public int  Horror;
        public int  Musical;
        public int Mystery;
        public int  Romancepublic;
        public int  SciFi;
        public int Thriller; 
        public int War;
        public int  Western ;

    }

