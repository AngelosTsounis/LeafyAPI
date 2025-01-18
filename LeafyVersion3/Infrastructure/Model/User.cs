namespace LeafyVersion3.Infrastructure.Model
{
    public class User
    {
        public Guid Id { get; set; }
        public string? Username { get; set; }
        public string? PasswordHash { get; set; } = null;
    }
}
