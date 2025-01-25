using Microsoft.EntityFrameworkCore;
using PlatformServices.Models;

namespace PlatformServices.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options ):base(options) 
        { 

        }
        public DbSet<Platform> platforms { get; set; }
        
    }
}
