using FileHelpers;
using RecSystem.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using RecSystem.Data;

namespace RecSystem.Models
{
    
    public static class AddDataToTable
      
    {
        static ApplicationDbContext _context;
        
        public static void SeedGenre()
        {
            
            var engine = new FileHelperEngine<GenreTable>();
            var records = engine.ReadFile("genre", 'r');

            foreach (var record in records)
            {
                Genre item = new Genre();
                {

                item.ID = record.id;
                item.Name = record.name;
                
                

                }_context.Genres.Add(item);
                
            }
            _context.SaveChangesAsync();

        }

        
        public static void SeedFilms()
        {
            var  engine = new FileHelperEngine<ItemTable>();
            var filmsStr = engine.ReadFile("item",'r');
            foreach (var str in filmsStr)
            {
                List<int> value = new List<int>() {str.Unknown, str.Action, str.Adventure, str.Animation, str.Children, str.Comedy, str.Crime,
                    str.Documentary, str.Drama, str.Fantasy, str.FilmNoir, str.Horror, str.Musical, str.Mystery,
                    str.Romancepublic, str.SciFi, str.Thriller, str.War, str.Western };

                Item item = new Item();
                {
                item.ID = str.id;
                item.MovieTitle = str.title;
                item.ReleaseDate = str.releaseDate;
                item.VideoReleaseDate = str.videoReleaseDate;
                    for (int i = 0; i < 20; i++)
                    {
                        if (value[i]== 1)
                        {
                            ItemGenres itemg = new ItemGenres();
                            {
                                itemg.ItemID = str.id;
                                itemg.GenreID = i;
                            }
                            _context.ItemGenres.Add(itemg);
                        }

                        

                    }
                    _context.Items.Add(item);
                    _context.SaveChangesAsync();
                }
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
    [DelimitedRecord(",")]
    public class ItemTable
    {
        public int id;
        public string title;
        [FieldConverter(ConverterKind.Date,"")]
        public DateTime releaseDate;
        [FieldConverter(ConverterKind.Date, "")]
        public DateTime videoReleaseDate;
        public string IMDb_URL;
        public byte Unknown;
        public byte Action;
        public byte Adventure;
        public byte Animation;
        public byte Children;
        public byte Comedy;
        public byte Crime;
        public byte Documentary;
        public byte Drama;
        public byte Fantasy;
        public byte FilmNoir;
        public byte  Horror;
        public byte  Musical;
        public byte Mystery;
        public byte  Romancepublic;
        public byte  SciFi;
        public byte Thriller; 
        public byte War;
        public byte  Western ;

    }

