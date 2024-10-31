namespace LeafyVersion3.Contracts.Responses
{
    public class RecyclingActivityResponse
    {
        public Guid Id { get; set; }
        public required string MaterialType { get; set; }
        public required double Quantity { get; set; }
        public int PointsAwarded { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
    }
}
