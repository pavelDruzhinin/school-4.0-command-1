using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RecSystem;
using RecSystem.Data;

namespace GetAdditionalInformation
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
               .AddLogging()
               .AddDbContext<ApplicationDbContext>(options => options.UseSqlServer("Server=tcp:recsystemdb.database.windows.net,1433;Initial Catalog=RecSystem;Persist Security Info=False;User ID=dbRecUser;Password=Hackaton2018;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"), ServiceLifetime.Transient)
               .AddTransient<AdditionalInfo>()
               .BuildServiceProvider();

            var service = serviceProvider.GetService<AdditionalInfo>();
            service.insertUrl();
        }
    }
}
