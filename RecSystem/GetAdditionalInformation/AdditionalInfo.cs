using HtmlAgilityPack;
using RecSystem.Data;
using System;
using System.Text.RegularExpressions;

namespace GetAdditionalInformation
{
    class AdditionalInfo
    {
        private ApplicationDbContext _context;
        private HtmlWeb web;
        private HtmlDocument htmlDoc;
        private HtmlNode hnPoster;

        public AdditionalInfo(ApplicationDbContext context)
        {
            _context = context;
        }

        public void insertUrl()
        {
            Console.WriteLine("Ожидайте идёт добавление ссылок...");
            string urlBase = "https://www.rottentomatoes.com/m/";
            string addPartPath;
            string posterPath = "//body/div/div/div/div/div/div/a/img";
            web = new HtmlWeb();
            foreach (var i in _context.Items)
            {
                addPartPath = i.MovieTitle;
                addPartPath = Regex.Replace(addPartPath, @"\b(\s{1}([(0-9)]{6}))$", "");
                addPartPath = Regex.Replace(addPartPath, @"\s", "_");

                try
                {
                    htmlDoc = web.Load(urlBase + addPartPath);
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine(urlBase + addPartPath + "\n " + "Некорректный адресс, возникла ошибка: " + ex.Message);
                    Console.ReadLine();
                    System.Environment.Exit(0);
                }
                i.Url = htmlDoc
                    .DocumentNode
                    .SelectSingleNode(posterPath)
                    .Attributes["src"]
                    .Value;
                _context.Items.Update(i);
            }
            _context.SaveChangesAsync();
        }
    }
}
