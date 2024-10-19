using LeafyVersion3.Infrastructure.Model;
using Microsoft.EntityFrameworkCore;

namespace LeafyAPI.Infrastructure.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }         
        public DbSet<RecyclingActivity> RecyclingActivities { get; set; }
    }
}
