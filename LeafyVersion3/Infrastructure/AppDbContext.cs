using LeafyVersion3.Infrastructure.Model;
using Microsoft.EntityFrameworkCore;

namespace LeafyAPI.Infrastructure.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }         
        public DbSet<RecyclingActivity> RecyclingActivities { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the one-to-many relationship
            modelBuilder.Entity<RecyclingActivity>()
                .HasOne(r => r.User)
                .WithMany() // If you don’t want to add a collection in User
                .HasForeignKey(r => r.UserId) // Maps UserId in RecyclingActivity to Id in User
                .OnDelete(DeleteBehavior.Cascade); // Deletes recycling activities when user is deleted
        }
    }
}
