using RecSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecSystem.ViewModels
{
    public class MessageViewModel
    {
        public string MessageUser { get; set; }
        public bool IsVisibleTable { get; set; }

        public MessageViewModel() { }
    }
}
