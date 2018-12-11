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
               .AddDbContext<ApplicationDbContext>(options => options.UseMySQL("Server=mysql5.locum.ru;Database=danteato_RecSy37;User ID=danteato_RecSy37;Password=hackaton2018;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;MultipleActiveResultSets=True"), ServiceLifetime.Transient)
               .AddTransient<AdditionalInfo>()
               .BuildServiceProvider();

            var service = serviceProvider.GetService<AdditionalInfo>();
            service.insertUrl();
        }
    }
}
