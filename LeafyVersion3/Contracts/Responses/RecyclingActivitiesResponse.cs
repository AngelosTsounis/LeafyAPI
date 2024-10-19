namespace LeafyVersion3.Contracts.Responses
{
    public class RecyclingActivitiesResponse
    {
        public IEnumerable<RecyclingActivityResponse> Items { get; set; } = Enumerable.Empty<RecyclingActivityResponse>();
    }
}
