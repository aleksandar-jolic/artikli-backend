using Artikli.Model;
using Microsoft.EntityFrameworkCore;

namespace Artikli.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Artikal> Artikli { get; set; }
    }
}
