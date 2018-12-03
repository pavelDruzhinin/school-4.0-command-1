using Microsoft.AspNetCore.Identity;
using FileHelpers;
using System;

namespace RecSystem.Models
{
    public class IdentityDataInit
    {
         public static void SeedUsers(UserManager<Customer> userManager)
        {
            try
            {
                var engine = new FileHelperEngine<Cust>();
                var records = engine.ReadFile("new_csv.csv",'r');

                foreach (var record in records)
                {
                    if (userManager.FindByNameAsync(record.name).Result == null)
                    {
                        Customer user = new Customer();
                        user.UserName = record.name;
                        user.Name = record.name;
                        user.Email = record.email;

                        IdentityResult result = userManager.CreateAsync
                        (user, "Kc84XgQs!").Result;


                    }

                }

            }
            catch (Exception ex)
            {
               
            }

        }
    }
    [IgnoreEmptyLines]
    [DelimitedRecord(",")]
    public class Cust 
    {        
        public string age;
        public string sex;
        public string name;
        public string code;
        public string email;


    }
}
