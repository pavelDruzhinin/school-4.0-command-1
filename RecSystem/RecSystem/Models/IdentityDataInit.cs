using Microsoft.AspNetCore.Identity;
using FileHelpers;
using System;
using System.Collections.Generic;

namespace RecSystem.Models
{
    public class IdentityDataInit
    {
         public List<string> SeedUsers(UserManager<Customer> userManager)
        {
            List<string> usersId = new List<string>();
            try
            {
                var engine = new FileHelperEngine<Cust>();
                var records = engine.ReadFile("new_csv.csv");
                            

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

                        usersId.Add(userManager.GetUserIdAsync(user).Result);
                    }
                    else {
                    string ud = userManager.FindByNameAsync(record.name).Result.Id;
                    usersId.Add(ud); 
                     }
                }

            }
            catch (Exception ex)
            {
               
            }
            return usersId;
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
