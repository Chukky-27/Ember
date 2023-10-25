using AutoMapper;
using Ember.Core.IServices;
using Ember.Domain.Model;
using Ember.Infrastructure;
using Ember.Infrastructure.DTO;
using Ember.Infrastructure.DTO.RequestDto;
using Microsoft.AspNetCore.Mvc;

namespace Ember.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FragranceController : ControllerBase
    {
        private readonly MyDbContext dbContext;
        private readonly IEmberService emberService;
        private readonly IMapper mapper;
              

        public FragranceController(MyDbContext dbContext, IEmberService emberService, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.emberService = emberService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var fragranceDomain = await emberService.GetAllAsync();
            return Ok(mapper.Map<List<FragranceDTO>>(fragranceDomain));
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromBody] string id)
        {
            var fragranceDomain = await emberService.GetIdAsync(id);
            if (fragranceDomain == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<FragranceDTO>(fragranceDomain));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddFragranceRequestDto addFragranceRequestDto)
        {
            var fragranceDomainModel = mapper.Map<Fragrance>(addFragranceRequestDto);
            fragranceDomainModel =  await emberService.CreateAsync(fragranceDomainModel);

            var fragranceDto = mapper.Map<FragranceDTO>(fragranceDomainModel);
            return CreatedAtAction(nameof(GetById), new { id = fragranceDto.Id }, fragranceDto);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult>Update([FromRoute] string id, [FromBody] UpdateFragranceRequestDto updateFragranceRequestDto)
        {
            var fragranceDomainModel = mapper.Map<Fragrance>(updateFragranceRequestDto);

            fragranceDomainModel = await emberService.UpdateAsync(id, fragranceDomainModel);
            if(fragranceDomainModel == null)
                return NotFound();
            return Ok (mapper.Map<FragranceDTO>(fragranceDomainModel));
        }
    }
}
