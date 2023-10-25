using Ember.Core.IServices;
using Ember.Domain.Model;
using Ember.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Ember.Core.Services
{
    public class EmberService : IEmberService
    {
        private readonly MyDbContext dbContext;

        public EmberService(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Fragrance>CreateAsync(Fragrance fragrance)
        {
            await dbContext.Fragrances.AddAsync(fragrance);
            await dbContext.SaveChangesAsync();

            return fragrance;
        }

        public async Task<List<Fragrance>> GetAllAsync()
        {
            return await dbContext.Fragrances.ToListAsync();
        }

        public async Task<Fragrance>GetIdAsync(string id)
        {
            return await dbContext.Fragrances.FirstOrDefaultAsync(j=>j.Id==id);
        }
        
        public async Task<Fragrance?> UpdateAsync(string id, Fragrance fragrance)
        {
            var exisitingFragrance = await dbContext.Fragrances.FirstOrDefaultAsync(b=>b.Id==id);
            if(exisitingFragrance == null)
            {
                return null;
            }
            exisitingFragrance.Id = id;
            exisitingFragrance.Brand = fragrance.Brand;
            exisitingFragrance.Price = fragrance.Price;
            exisitingFragrance.Intensity = fragrance.Intensity;
            exisitingFragrance.Description = fragrance.Description;
            exisitingFragrance.Preference = fragrance.Preference;
            exisitingFragrance.Type = fragrance.Type;
            exisitingFragrance.VolumeInMilliliters = fragrance.VolumeInMilliliters;
            await dbContext.SaveChangesAsync();
            return exisitingFragrance;
        }
    }
}
