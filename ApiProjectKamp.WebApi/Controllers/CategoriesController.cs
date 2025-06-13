using ApiProjectKamp.WebApi.Context;
using ApiProjectKamp.WebApi.Dtos.CategoryDtos;
using ApiProjectKamp.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjectKamp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ApiContext _context;

        public CategoriesController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult CategoryList()
        {
            var values = _context.Categories.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryDto createCategoryDto)
        {
            var value = _mapper.Map<Category>(createCategoryDto);
            _context.Categories.Add(value);
            _context.SaveChanges();
            return Ok("Kategori ekleme işlemi başarılı");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var result = _context.Categories.Find(id);
            _context.Categories.Remove(result);
            _context.SaveChanges();
            return Ok("Kategori silme işlemi başarılı.");
        }

        [HttpGet("GetCategory/{id}")]
        public IActionResult GetCategory(int id)
        {
            var values = _context.Categories.Find(id);
            return Ok(values);
        }

        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            var result = _mapper.Map<Category>(updateCategoryDto);
            _context.Categories.Update(result);
            _context.SaveChanges();
            return Ok("Kategori güncelleme işlemi başarılı.");
        }

    }
}
