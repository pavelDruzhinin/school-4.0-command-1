using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecSystem.Models;

namespace RecSystem.ViewModels
{
    public class PrivateViewModel

    {
        public int ID { get; set; }
        public List<PrivateItemViewModel> Items { get; set; }
    }

    public class PrivateItemViewModel
    {
        
        public string Title { get; set; }
        public int Score { get; set; }
    }
}
