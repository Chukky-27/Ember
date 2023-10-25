using AutoMapper;
using Ember.Domain.Model;
using Ember.Infrastructure.DTO;
using Ember.Infrastructure.DTO.RequestDto;

namespace Ember.Infrastructure.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Fragrance, FragranceDTO>().ReverseMap();
            CreateMap<AddFragranceRequestDto, Fragrance>().ReverseMap();
            CreateMap<UpdateFragranceRequestDto, Fragrance>().ReverseMap();
        }

        
    }
}
