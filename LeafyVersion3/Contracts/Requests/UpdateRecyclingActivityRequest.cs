﻿namespace LeafyVersion3.Contracts.Requests
{
    public class UpdateRecyclingActivityRequest
    {
        public required string MaterialType { get; set; }
        public required double Quantity { get; set; }
        public required string Location { get; set; }
    }
}
