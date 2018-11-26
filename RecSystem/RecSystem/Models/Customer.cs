using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace RecSystem.Models
{
    public class Customer : IdentityUser
    {
        public string Name { get; set; }

    }
}
