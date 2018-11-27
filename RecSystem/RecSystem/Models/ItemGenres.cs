using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecSystem.Models
{
    public class ItemGenres
    {
        public int ID { get; set; }
        public int ItemID { get; set; }
        public Item Item { get; set; }
        public int GenreID { get; set; }
        public Genre Genre { get; set; }
    }
}
