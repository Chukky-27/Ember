using Ember.Domain.Model;
using Ember.Infrastructure.DTO;

namespace Ember.Core.IServices
{
    public interface IEmberService
    {
        Task<string> CreateFragranceAsync(FragranceDTO fragranceDTO);
        Task<List<Fragrance>> GetAllAsync();
        Task<Fragrance> GetFragranceByIdAsync(string UserId);
        Task<string> UpdateByIdAsync(string userId, FragranceDTO fragranceDTO);
        Task<string> DeleteFragranceByIdAsync(string userId);
    }
}
