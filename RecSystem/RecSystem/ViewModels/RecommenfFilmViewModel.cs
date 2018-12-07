using RecSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecSystem.ViewModels
{
    public class RecommenfFilmViewModel
    {
        public List<Item> RecommendFilmList { get; set; }
        public string MessageUser { get; set; }
        public bool VisibleTable { get; set; }

        public RecommenfFilmViewModel() { }
        public RecommenfFilmViewModel(List<Item> recommendIdItemList)
        {
            RecommendFilmList = recommendIdItemList;
            if (recommendIdItemList.Count() == 0)
            {
                MessageUser = @"Для расчета рекомендаций необходимо, чтобы Вы оценили большее количество фильмов!";
                VisibleTable = false;
            }
            else VisibleTable = true;
        }
    }
}
