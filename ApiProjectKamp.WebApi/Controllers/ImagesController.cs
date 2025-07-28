using ApiProjectKamp.WebApi.Context;
using ApiProjectKamp.WebApi.Dtos.ImageDtos;
using ApiProjectKamp.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjectKamp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ApiContext _context;

        public ImagesController(IMapper mapper, ApiContext context)
        {
            _mapper = mapper;
            _context = context;
        }


        [HttpGet]
        public IActionResult ImageList()
        {
            var values = _context.Images.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateImage(CreateImageDto createImageDto)
        {
            var value = _mapper.Map<Image>(createImageDto);
            _context.Images.Add(value);
            _context.SaveChanges();
            return Ok("Görsel ekleme işlemi başarılı");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteImage(int id)
        {
            var result = _context.Images.Find(id);
            _context.Images.Remove(result);
            _context.SaveChanges();
            return Ok("Görsel silme işlemi başarılı.");
        }

        [HttpGet("GetImage/{id}")]
        public IActionResult GetImage(int id)
        {
            var values = _context.Images.Find(id);
            return Ok(values);
        }

        [HttpPut]
        public IActionResult UpdateImage(UpdateImageDto updateImageDto)
        {
            var result = _mapper.Map<Image>(updateImageDto);
            _context.Images.Update(result);
            _context.SaveChanges();
            return Ok("Görsel güncelleme işlemi başarılı.");
        }
    }
}
