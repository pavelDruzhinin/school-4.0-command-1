using System;
using System.Collections.Generic;
using System.Text;
using RecSystem.Data;
using System.IO;
using System.Text.RegularExpressions;
using RecSystem.Models;

namespace PushData
{
    class PPData
    {
        private ApplicationDbContext _context;
        private StreamReader sr;
        private Item newItem;

        public PPData(ApplicationDbContext context)
        {
            _context = context;
        }


        public void pushData()
        {
            string path="";
            string line;
            string[] itemData;
            sr = new StreamReader(path, System.Text.Encoding.Default);
            while((line=sr.ReadLine())!=null)
            {
              itemData=Regex.Split(line, "|");
                foreach(var s in itemData)
                {
                    
                }
            }

        }
    }
}
