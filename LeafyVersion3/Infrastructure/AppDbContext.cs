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

           
            modelBuilder.Entity<RecyclingActivity>()
                .HasOne(r => r.User)
                .WithMany()  
                .HasForeignKey(r => r.UserId)  
                .OnDelete(DeleteBehavior.Cascade);  
        }
    }
}
