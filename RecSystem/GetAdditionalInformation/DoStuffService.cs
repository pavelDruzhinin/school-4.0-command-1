using RecSystem.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace GetAdditionalInformation
{
    class DoStuffService
    {
        private ApplicationDbContext _context;
        
        public DoStuffService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void DoStuff()
        {
            Console.WriteLine("HUI");
        }
    }
}
