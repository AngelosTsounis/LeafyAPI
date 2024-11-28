namespace LeafyVersion3.Infrastructure.Model;

public class RecyclingActivity
{
    public Guid Id { get; set; }

    public required string MaterialType { get; set; }
    public required double Quantity { get; set; }
    public int PointsAwarded { get; set; }
    public DateTime Date { get; set; } = DateTime.UtcNow;

    // Correctly link UserId as a foreign key to User.Id
    public Guid UserId { get; set; } // This is the foreign key
    public User User { get; set; } = null!; // Navigation property
}
