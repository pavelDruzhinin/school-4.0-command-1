using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecSystem.Models
{
    public class Rating
    {
        public int ID { get; set; }
        public int Score { get; set; }
        public int ItemID { get; set; }
        public Item Item { get; set; }
        public string CustomerId { get; set; }
        public Customer Customer { get; set; }

    }
}
