﻿using LeafyVersion3.Contracts.Requests;
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
            };
        }

        public static RecyclingActivity MapToRecyclingActivity(this UpdateRecyclingActivityRequest request)
        {
            return new RecyclingActivity
            {
                Id = Guid.NewGuid(),
                MaterialType = request.MaterialType,
                Quantity = request.Quantity,
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
