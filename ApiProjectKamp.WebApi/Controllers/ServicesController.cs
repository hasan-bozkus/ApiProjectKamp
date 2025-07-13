using ApiProjectKamp.WebApi.Context;
using ApiProjectKamp.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjectKamp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly ApiContext _context;

        public ServicesController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult ServiceList()
        {
            var values = _context.Services.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateService(Service service)
        {
            _context.Services.Add(service);
            _context.SaveChanges();
            return Ok("Servis ekleme işlemi başarılı");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteService(int id)
        {
            var result = _context.Services.Find(id);
            _context.Services.Remove(result);
            _context.SaveChanges();
            return Ok("Servis silme işlemi başarılı.");
        }

        [HttpGet("GetService/{id}")]
        public IActionResult GetService(int id)
        {
            var values = _context.Services.Find(id);
            return Ok(values);
        }

        [HttpPut]
        public IActionResult UpdateService(Service service)
        {
            _context.Services.Update(service);
            _context.SaveChanges();
            return Ok("Servis güncelleme işlemi başarılı.");
        }
    }
}
