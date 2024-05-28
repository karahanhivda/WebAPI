using Microsoft.EntityFrameworkCore;
using WebAPIGirisss.Data;

namespace WebAPIGirisss.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Araba> Arabalar { get; set; }
        public DbSet<Blok>  Bloklar { get; set; }
        public AppDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }
    }

}



