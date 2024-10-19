using LeafyAPI.Infrastructure.Models;
using LeafyVersion3.Infrastructure.Model;
using Microsoft.EntityFrameworkCore;

namespace LeafyVersion3.Infrastructure.Repositories
{
    public class RecyclingActivityRepository : IRecyclingActivityRepository
    {
        protected readonly AppDbContext _context;

        public RecyclingActivityRepository(AppDbContext context)
        {

            _context = context;

        }

        public async Task<RecyclingActivity> Create(RecyclingActivity activityToInsert)
        {
            if (activityToInsert == null)
            {
                throw new ArgumentNullException(nameof(activityToInsert));
            }

            await _context.RecyclingActivities.AddAsync(activityToInsert);
            await _context.SaveChangesAsync();

            return activityToInsert;

        }
        public async Task<IEnumerable<RecyclingActivity>> GetAllAsync()
        {
            return await _context.RecyclingActivities.ToListAsync();
        }

        public async Task<RecyclingActivity> GetByIdAsync(Guid id)
        {
            return await _context.RecyclingActivities.FindAsync(id);
          
        }

        public async Task UpdateAsync(RecyclingActivity entity)
        {
            _context.RecyclingActivities.Update(entity);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAllAsync()
        {
           var allActivities = await _context.RecyclingActivities.ToListAsync();
            _context.RecyclingActivities.RemoveRange(allActivities);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var activity = await _context.RecyclingActivities.FindAsync(id);

            if (activity != null)
            {  
                _context.RecyclingActivities.Remove(activity);
                await _context.SaveChangesAsync();  
            }
        }
    }
}
