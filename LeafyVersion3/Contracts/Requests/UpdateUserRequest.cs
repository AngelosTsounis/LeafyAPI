namespace LeafyVersion3.Contracts.Requests
{
    public class UpdateUserRequest
    {
        public Guid UserId { get; set; } 
        public string? Username { get; set; }
        public string? PasswordHash { get; set; }
    }
}
