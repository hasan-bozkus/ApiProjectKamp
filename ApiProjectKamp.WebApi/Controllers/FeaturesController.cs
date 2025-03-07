using ApiProjectKamp.WebApi.Context;
using ApiProjectKamp.WebApi.Dtos.FeaturesDtos;
using ApiProjectKamp.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiProjectKamp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public FeaturesController(IMapper mapper, ApiContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> FeatureList()
        {
            var values = _mapper.Map<List<ResultFeatureDto>>(await _context.Features.ToListAsync());
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeatuer(CreateFeatureDto createFeatureDto)
        {
            var feature = _mapper.Map<Feature>(createFeatureDto);
            await _context.Features.AddAsync(feature);
            await _context.SaveChangesAsync();
            return Ok("Ekleme işlemi başarılı");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeature(int id)
        {
            var value = await _context.Features.FindAsync(id);
            _context.Features.Remove(value);
            await _context.SaveChangesAsync();
            return Ok("Silme işlemi başarılı");
        }

        [HttpGet("GetFeature/{id}")]
        public async Task<IActionResult> GetFeature(int id)
        {
            var value = _mapper.Map<ResultFeatureDto>(await _context.Features.FindAsync(id));
            return Ok(value);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            var value = _mapper.Map<Feature>(updateFeatureDto);
            _context.Features.Update(value);
            await _context.SaveChangesAsync();
            return Ok("Güncelleme işlemi başarılı");
        }
    }
}
