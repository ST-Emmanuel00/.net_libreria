using Libreria.Models;
using Microsoft.EntityFrameworkCore;

namespace Libreria.Data
{
    public class AplicationDbContext : DbContext
    {

        public AplicationDbContext(DbContextOptions<AplicationDbContext>options) : base(options)
        {


        }

        public DbSet<Libro> libro { get; set; }


    }
}
