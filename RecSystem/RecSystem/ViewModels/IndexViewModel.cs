using RecSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecSystem.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<Item> Items { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}
