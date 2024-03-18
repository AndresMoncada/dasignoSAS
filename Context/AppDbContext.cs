using dasignoSAS.Models;
using Microsoft.EntityFrameworkCore;

namespace dasignoSAS.Context
{
    public class AppDbContext: DbContext 
    {
        public AppDbContext( DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
    }
}
