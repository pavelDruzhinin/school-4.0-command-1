using RecSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecSystem.ViewModels
{
    public class RatedFilmsViewModel : MessageViewModel
    {
        public List<Rating> RatedFilmList { get; set; }

        public RatedFilmsViewModel(List<Rating> ratedFilmList)
        {
            RatedFilmList = ratedFilmList;
            if (ratedFilmList.Count() == 0)
            {
                MessageUser = @"Вы пока не оценили ни одного фильма";
                IsVisibleTable = false;
            }
            else IsVisibleTable = true;
        }
    }
}
