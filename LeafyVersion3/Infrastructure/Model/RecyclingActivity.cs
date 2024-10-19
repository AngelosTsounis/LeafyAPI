namespace LeafyVersion3.Infrastructure.Model
{
    public class RecyclingActivity
    {
        public Guid Id { get; set; }
        public required string MaterialType {  get; set; }
        public required double Quantity { get; set; }
        public DateTime Date { get; set; }

    }
}
