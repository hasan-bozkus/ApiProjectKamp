using ApiProjectKamp.WebApi.Context;
using ApiProjectKamp.WebApi.Dtos.AboutDtos;
using ApiProjectKamp.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiProjectKamp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ApiContext _context;

        public AboutsController(IMapper mapper, ApiContext context)
        {
            _mapper = mapper;
            _context = context;
        }


        [HttpGet]
        public IActionResult AboutList()
        {
            var values = _context.Abouts.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateAbout(CreateAboutDto createAboutDto)
        {
            var value = _mapper.Map<About>(createAboutDto);
            _context.Abouts.Add(value);
            _context.SaveChanges();
            return Ok("Hakkımda ekleme işlemi başarılı");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAbout(int id)
        {
            var result = _context.Abouts.Find(id);
            _context.Abouts.Remove(result);
            _context.SaveChanges();
            return Ok("Hakkımda silme işlemi başarılı.");
        }

        [HttpGet("GetAbout/{id}")]
        public IActionResult GetAbout(int id)
        {
            var values = _context.Abouts.Find(id);
            return Ok(values);
        }

        [HttpPut]
        public IActionResult UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            var result = _mapper.Map<About>(updateAboutDto);
            _context.Abouts.Update(result);
            _context.SaveChanges();
            return Ok("Hakkımda güncelleme işlemi başarılı.");
        }
    }
}
