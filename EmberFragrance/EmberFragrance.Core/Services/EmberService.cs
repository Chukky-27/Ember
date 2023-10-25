using Ember.Core.IServices;
using Ember.Domain.Model;
using Ember.Infrastructure;
using Ember.Infrastructure.DTO;
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

        public async Task<string> CreateFragranceAsync(FragranceDTO fragranceDTO)
        {
            //await dbContext.Fragrances.AddAsync(fragrance);
            //await dbContext.SaveChangesAsync();

            //return fragrance;
            try
            {
                var fragrance = new Fragrance()
                {
                    Name = fragranceDTO.Name,
                    Id = fragranceDTO.Id,
                    IsDeleted = false,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    Preference = fragranceDTO.Preference,
                    Intensity = fragranceDTO.Intensity,
                    Brand = fragranceDTO.Brand,
                    Price = fragranceDTO.Price,
                    Type = fragranceDTO.Type,
                };
                await dbContext.Fragrances.AddAsync(fragrance);
                await dbContext.SaveChangesAsync();
                return $"{fragranceDTO.Name} Order placed successfully";
            }
            catch (Exception ex)
            {
                throw new Exception(ex. Message );
            }
        }

        public async Task<List<Fragrance>> GetAllAsync()
        {
            return await dbContext.Fragrances.ToListAsync();
        }
        
        public async Task<string> UpdateByIdAsync(string userId, FragranceDTO fragranceDTO)
        {
            var exisitingFragrance = await dbContext.Fragrances.FirstOrDefaultAsync(b=>b.Id==userId);
            if( exisitingFragrance == null)
            {
                throw new Exception($"{userId} does not exist");
            }
            exisitingFragrance.Name = exisitingFragrance.Name;
            exisitingFragrance.Brand = exisitingFragrance.Brand;
            exisitingFragrance.Description = exisitingFragrance.Description;
            exisitingFragrance.Price = exisitingFragrance.Price;
            exisitingFragrance.Intensity = exisitingFragrance.Intensity;
            exisitingFragrance.Preference = exisitingFragrance.Preference;

            var output =  dbContext.Fragrances.Update(exisitingFragrance);
            await dbContext.SaveChangesAsync();
            return "Frangrance updated successfully";

           
        }

        public async Task<Fragrance> GetFragranceByIdAsync(string UserId)
        {
            try
            {
                var fragrance = await dbContext.Fragrances.FirstOrDefaultAsync(b => b.Id == UserId);
                return fragrance ?? throw new InvalidOperationException("user not found");
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<string> DeleteFragranceByIdAsync(string userId)
        {
            try
            {
                var result = await dbContext.Fragrances.FirstOrDefaultAsync(x=>x.Id == userId);
                if(result == null)
                {
                    return $"{userId} not found";
                }
                dbContext.Fragrances.Remove(result);
                await dbContext.SaveChangesAsync();
                return $"{userId} deleted succesfully";
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

       
    }
}
