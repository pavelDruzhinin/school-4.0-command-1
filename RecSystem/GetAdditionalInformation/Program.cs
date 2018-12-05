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
               .AddDbContext<ApplicationDbContext>(options => options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=RecSystemDb;Trusted_Connection=True;MultipleActiveResultSets=true"), ServiceLifetime.Transient)
               .AddTransient<AdditionalInfo>()
               .BuildServiceProvider();

            var service = serviceProvider.GetService<AdditionalInfo>();
            service.insertUrl();
        }
    }
}
