using LeafyVersion3.Infrastructure.Model;
namespace LeafyVersion3.Infrastructure.Repositories
{
    public interface IRecyclingActivityRepository
    {
        Task<RecyclingActivity> Create(RecyclingActivity activityToInsert);
        Task<IEnumerable<RecyclingActivity>> GetAllAsync();
        Task<RecyclingActivity> GetByIdAsync(Guid id);
        Task UpdateAsync(RecyclingActivity entity);
        Task DeleteAsync(Guid id);
        Task DeleteAllAsync();
    }
}
