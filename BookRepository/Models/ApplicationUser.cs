using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRepository.Models
{
    public class ApplicationUser:IdentityUser
    {
        //public  FirstName { get; set; }
    public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
