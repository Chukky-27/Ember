using Ember.Domain.Model;

namespace Ember.Core.IServices
{
    public interface IEmberService
    {
        Task<Fragrance> CreateAsync(Fragrance fragrance);
        Task<List<Fragrance>> GetAllAsync();
        Task<Fragrance> GetIdAsync(string id);
        Task<Fragrance?> UpdateAsync(string id, Fragrance fragrance);
    }
}
