using LeafyVersion3.Contracts.Requests;
using LeafyVersion3.Contracts.Responses;
using LeafyVersion3.Infrastructure.Model;
using System.Runtime.CompilerServices;

namespace LeafyVersion3.Mappers
{
    public static class ContractMapping
    {

        public static RecyclingActivity MapToRecyclingActivity(this CreateRecyclingActivityRequest request)
        {
            return new RecyclingActivity
            {
                Id = Guid.NewGuid(),
                MaterialType = request.MaterialType,
                Quantity = request.Quantity,
                Location = request.Location,
            };
        }

        public static RecyclingActivity MapToRecyclingActivity(this UpdateRecyclingActivityRequest request)
        {
            return new RecyclingActivity
            {
                Id = Guid.NewGuid(),
                MaterialType = request.MaterialType,
                Quantity = request.Quantity,
                Location = request.Location,
            };
        }


        public static RecyclingActivityResponse MapToResponse(this RecyclingActivity response)
        {
            return new RecyclingActivityResponse
            {
                Id = response.Id,
                MaterialType = response.MaterialType,
                Quantity = response.Quantity,
                Date = response.Date,
                Location = response.Location,
                PointsAwarded = response.PointsAwarded

            };
        }

        public static RecyclingActivitiesResponse MapToResponse(this IEnumerable<RecyclingActivity> responses)
        {
            return new RecyclingActivitiesResponse
            {
                Items = responses.Select(MapToResponse),
                
            };
        }
    }
}
