using SeenServer.Domain;
using Microsoft.EntityFrameworkCore;

namespace SeenServer.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }

        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }
    }
}
