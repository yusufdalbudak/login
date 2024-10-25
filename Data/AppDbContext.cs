using Microsoft.EntityFrameworkCore;
using LoginWebsites.Models;  // Namespace'lerin projedeki adýyla eþleþtiðinden emin olun

namespace LoginWebsites.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
