using LeafyVersion3.Infrastructure.Model;

public class RecyclingSummaryService
{
    public object CalculateSummaryMetadata(IEnumerable<RecyclingActivity> activities)
    {
        // Calculate the total quantity of all items recycled
        var totalQuantity = activities.Sum(a => a.Quantity);
        var totalPoints = activities.Sum(a => a.PointsAwarded);

        // Group activities by MaterialType and calculate total for each material
        var materialBreakdown = activities
            .GroupBy(a => a.MaterialType)
            .Select(g => new
            {
                MaterialType = g.Key,
                TotalQuantity = g.Sum(a => a.Quantity),
                TotalPoints = totalPoints,
                Percentage = (g.Sum(a => a.Quantity) / totalQuantity) * 100
            })
            .ToList();

        // Find the material with the highest percentage
        var mostCommonMaterial = materialBreakdown
            .OrderByDescending(m => m.TotalQuantity)
            .FirstOrDefault();

        var summary = new
        {
            TotalQuantity = totalQuantity,
            Breakdown = materialBreakdown,
            MostCommonMaterial = mostCommonMaterial  // Include the most common material in the response
        };
        return summary;
    }
}
