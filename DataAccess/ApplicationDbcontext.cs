using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using DataModels.Models;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ApplicationDbcontext : DbContext
    {

        public ApplicationDbcontext( DbContextOptions<ApplicationDbcontext >  options ) :base(options)
        {
            
        }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

    }
}
