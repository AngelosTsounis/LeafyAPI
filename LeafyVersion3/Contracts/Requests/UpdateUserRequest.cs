﻿namespace LeafyVersion3.Contracts.Requests
{
    public class UpdateUserRequest
    {
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }
    }
}
