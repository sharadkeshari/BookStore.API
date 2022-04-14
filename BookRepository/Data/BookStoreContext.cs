using BookRepository.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRepository.Data
{
    public class BookStoreContext:IdentityDbContext<ApplicationUser>
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options ):base(options)
        {
        }

        public DbSet<Books> Books { get; set; }

        
        //... this below thing can be done at the level of startup class also
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=.;Database=BookStoreAPI;Integrated Security=True");
        //    base.OnConfiguring(optionsBuilder);
        //}
    }
}
