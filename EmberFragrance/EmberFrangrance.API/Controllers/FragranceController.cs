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
        //private readonly MyDbContext dbContext;
        private readonly IEmberService emberService;
        //private readonly IMapper mapper;
              

        public FragranceController(IEmberService emberService)
        {
            //this.dbContext = dbContext;
            this.emberService = emberService;
            //this.mapper = mapper;
        }

        //[HttpGet]
        //public async Task<IActionResult> GetAll()
        //{
        //    //var fragranceDomain = await emberService.GetAllAsync();
        //    //return Ok(mapper.Map<List<FragranceDTO>>(fragranceDomain));
        //}

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetFragranceById( string userId)
        {
            //var fragranceDomain = await emberService.GetIdAsync(id);
            //if (fragranceDomain == null)
            //{
            //    return NotFound();
            //}
            //return Ok(mapper.Map<FragranceDTO>(fragranceDomain));
            var result = await emberService.GetFragranceByIdAsync(userId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create( FragranceDTO fragranceDTO)
        {
            //var fragranceDomainModel = mapper.Map<Fragrance>(addFragranceRequestDto);
            //fragranceDomainModel =  await emberService.CreateAsync(fragranceDomainModel);

            //var fragranceDto = mapper.Map<FragranceDTO>(fragranceDomainModel);
            //return CreatedAtAction(nameof(GetById), new { id = fragranceDto.Id }, fragranceDto);
            var result = await emberService.CreateFragranceAsync(fragranceDTO);
            return Ok(result);
        }

        //[HttpPut]
        //[Route("{id:Guid}")]
        //public async Task<IActionResult>Update([FromRoute] string id, [FromBody] UpdateFragranceRequestDto updateFragranceRequestDto)
        //{
        //    //var fragranceDomainModel = mapper.Map<Fragrance>(updateFragranceRequestDto);

        //    //fragranceDomainModel = await emberService.UpdateAsync(id, fragranceDomainModel);
        //    //if(fragranceDomainModel == null)
        //    //    return NotFound();
        //    //return Ok (mapper.Map<FragranceDTO>(fragranceDomainModel));
        //}

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult>DeleteFragrance(string userId)
        {
            var output = await emberService.GetFragranceByIdAsync(userId);
            return Ok();
        }
    }
}
