using LeafyVersion3.Services;
using LeafyVersion3.Infrastructure.Model;
using LeafyVersion3.Infrastructure.Repositories;
using LeafyVersion3.Contracts.Requests;
using Microsoft.AspNetCore.Mvc;
using LeafyVersion3.Mappers;

namespace LeafyVersion3.Controllers
{
    [ApiController]
    [Route("api/recyclingActivity")]
    public class RecyclingActivityController : ControllerBase
    {
        private readonly IRecyclingActivityRepository _recyclingActivityRepository;
        private readonly RecyclingSummaryService _recyclingSummaryService;
        private readonly PointsCalculationService _pointsCalculationService;

        public RecyclingActivityController(
            IRecyclingActivityRepository recyclingActivityRepository,
            RecyclingSummaryService recyclingSummaryService,
            PointsCalculationService pointsCalculationService)
        {
            _recyclingActivityRepository = recyclingActivityRepository;
            _recyclingSummaryService = recyclingSummaryService;
            _pointsCalculationService = pointsCalculationService;
        }

        [HttpPost()]
        public async Task<IActionResult> CreateActivity(CreateRecyclingActivityRequest request)
        {
            if (request == null)
            {
                return BadRequest("Activity data is missing");
            }

            var activityToInsert = request.MapToRecyclingActivity();

            int points = _pointsCalculationService.CalculatePoints(request.MaterialType, request.Quantity);

            activityToInsert.PointsAwarded = points;

            await _recyclingActivityRepository.Create(activityToInsert);

            var response = activityToInsert.MapToResponse();
            return CreatedAtAction(nameof(GetActivitiesById), new { id = activityToInsert.Id }, response);
        }


        [HttpGet("{id}")]
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

        [HttpGet()]
        public async Task<IActionResult> GetAllActivities()
        {
            var activities = await _recyclingActivityRepository.GetAllAsync();

            var sortedActivities = activities.OrderByDescending(a => a.Date);

            var activitiesResponse = sortedActivities.MapToResponse();
            return Ok(activitiesResponse);
        }

        [HttpPut("{id}")]
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

        [HttpDelete()]

        public async Task<IActionResult> DeleteAll()
        {
            await _recyclingActivityRepository.DeleteAllAsync();
            return Ok("All activities have been deleted");
        }

        [HttpDelete("{id}")]

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

            if (!activities.Any())
            {
                return NotFound("No recycling activities found.");
            }

            var summary = _recyclingSummaryService.CalculateSummaryMetadata(activities);

            return Ok(summary);
        }
    }
}

