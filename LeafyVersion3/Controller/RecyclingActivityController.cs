using LeafyVersion3.Contracts.Requests;
using LeafyVersion3.Infrastructure.Repositories;
using LeafyVersion3.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace LeafyVersion3.Controllers
{
    [ApiController]
    [Route("api/recyclingActivity")]
    public class RecyclingActivityController : ControllerBase
    {
        private readonly IRecyclingActivityRepository _recyclingActivityRepository;

        public RecyclingActivityController(IRecyclingActivityRepository recyclingActivityRepository)
        {
            _recyclingActivityRepository = recyclingActivityRepository;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateActivity(CreateRecyclingActivityRequest request)
        {
            if (request == null)
            {
                return BadRequest("Activity data is missing");
            }

            var activityToInsert = request.MapToRecyclingActivity();

            await _recyclingActivityRepository.Create(activityToInsert);

            return CreatedAtAction(nameof(GetActivitiesById), new { id = activityToInsert.Id }, activityToInsert);
        }

        [HttpGet("getBy/{id}")]
        public async Task<IActionResult> GetActivitiesById(Guid id)
        {
            var activity = await _recyclingActivityRepository.GetByIdAsync(id);

            if (activity == null)
            {
                return NotFound();
            }

            var response = activity.MapToResponse();

            return Ok(response);
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllActivities()
        {
            var activities = await _recyclingActivityRepository.GetAllAsync();
            var activitiesResponse = activities.MapToResponse();

            return Ok(activitiesResponse);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateActivity(Guid id, UpdateRecyclingActivityRequest request)
        {
            var activity = await _recyclingActivityRepository.GetByIdAsync(id);
            if (activity == null)
            {
                return NotFound();
            }

            activity.MaterialType = request.MaterialType;
            activity.Quantity = request.Quantity;

            await _recyclingActivityRepository.UpdateAsync(activity);

            return NoContent();
        }

        [HttpDelete("delete-all")]

        public async Task<IActionResult> DeleteAll()
        {
            await _recyclingActivityRepository.DeleteAllAsync();
            return Ok("All activities have been deleted");
        }

        [HttpDelete("deleteBy/{id}")]

        public async Task<IActionResult> DeleteById(Guid id)
        {
            var activity = await _recyclingActivityRepository.GetByIdAsync(id);

            if (activity == null)
            {
                return NotFound($"User with Id {id} was not found");
            }
            await _recyclingActivityRepository.DeleteAsync(id);
            return Ok();
        }


        [HttpGet("summary")]
        public async Task<IActionResult> GetRecyclingSummary()
        {
            var activities = await _recyclingActivityRepository.GetAllAsync();

            if (activities == null || !activities.Any())
            {
                return NotFound("No recycling activities found.");
            }

            // Calculate the total quantity of all items recycled
            var totalQuantity = activities.Sum(a => a.Quantity);

            // Group activities by MaterialType and calculate total for each material
            var materialBreakdown = activities
                .GroupBy(a => a.MaterialType)
                .Select(g => new
                {
                    MaterialType = g.Key,
                    TotalQuantity = g.Sum(a => a.Quantity),
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

            return Ok(summary);
        }


    }
}

