using ApiProjectKamp.WebApi.Context;
using ApiProjectKamp.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjectKamp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController : ControllerBase
    {
        private readonly ApiContext _context;

        public TestimonialsController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult TestimonialList()
        {
            var values = _context.Testimonials.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateTestimonial(Testimonial Testimonial)
        {
            _context.Testimonials.Add(Testimonial);
            _context.SaveChanges();
            return Ok("Ekleme işlemi başarılı");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTestimonial(int id)
        {
            var result = _context.Testimonials.Find(id);
            _context.Testimonials.Remove(result);
            _context.SaveChanges();
            return Ok("Silme işlemi başarılı.");
        }

        [HttpGet("GetTestimonial/{id}")]
        public IActionResult GetTestimonial(int id)
        {
            var values = _context.Testimonials.Find(id);
            return Ok(values);
        }

        [HttpPut]
        public IActionResult UpdateTestimonial(Testimonial Testimonial)
        {
            _context.Testimonials.Update(Testimonial);
            _context.SaveChanges();
            return Ok("Güncelleme işlemi başarılı.");
        }

    }
}
