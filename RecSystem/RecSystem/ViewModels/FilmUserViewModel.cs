using RecSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecSystem.ViewModels
{
    public class FilmUserViewModel : Item
    {
        public int ScoreUser { get; set; }
        public string IdUser { get; set; }

        public FilmUserViewModel() { }
    }
}
