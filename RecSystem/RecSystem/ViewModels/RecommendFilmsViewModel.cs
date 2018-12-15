using RecSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecSystem.ViewModels
{
    public class RecommendFilmsViewModel : MessageViewModel
    {
        public List<Item> RecommendFilmList { get; set; }

        public RecommendFilmsViewModel(List<Item> recommendIdItemList)
        {
            RecommendFilmList = recommendIdItemList;
            if (recommendIdItemList.Count() == 0)
            {
                MessageUser = @"You have to score more movies to get recommendations.";
                IsVisibleTable = false;
            }
            else IsVisibleTable = true;
        }
    }
}
