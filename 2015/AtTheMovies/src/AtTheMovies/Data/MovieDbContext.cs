using AtTheMovies.Models;
using Microsoft.EntityFrameworkCore;

namespace AtTheMovies.Data
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions options)
            : base(options)
        {
            
        }

        public DbSet<Movie> Movies { get; set; }
    }
}
