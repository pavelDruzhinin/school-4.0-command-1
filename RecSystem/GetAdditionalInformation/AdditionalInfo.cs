using HtmlAgilityPack;
using RecSystem.Data;
using System;
using System.Text.RegularExpressions;

namespace getadditionalinformation
{
    class additionalinfo
    {
        private ApplicationDbContext _context;

        public additionalinfo(ApplicationDbContext context)
        {
            _context = context;
        }

        public void insertUrl()
        {
            string urlBase = "https://www.rottentomatoes.com/m/";
            string addPartPath;
            foreach (var i in _context.Items)
            {
                addPartPath = i.MovieTitle;
                Regex.Replace(addPartPath, "\s(\d*)", "");
                addPartPath = addPartPath + " ";

            }
        }
    }
}
