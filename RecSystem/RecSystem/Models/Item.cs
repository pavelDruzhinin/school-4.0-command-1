using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecSystem.Models
{
    public class Item
    {
        public int ID { get; set; }
        public string MovieTitle { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public DateTime? VideoReleaseDate { get; set; }
        public List<ItemGenres> ItemGenres { get; set; }
        public List<Rating> Ratings { get; set; }
    }
}
