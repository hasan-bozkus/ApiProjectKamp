using ApiProjectKamp.WebApi.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ApiProjectKamp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly ApiContext _context;

        public StatisticsController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet("ProductCount")]
        public async Task<IActionResult> ProductCount()
        {
            var value = await _context.Products.CountAsync();
            return Ok(value);
        }

        [HttpGet("ReservationCount")]
        public async Task<IActionResult> ReservationCount()
        {
            var value = await _context.Reservations.CountAsync();
            return Ok(value);
        }

        [HttpGet("ChefCount")]
        public async Task<IActionResult> ChefCount()
        {
            var value = await _context.Chefs.CountAsync();
            return Ok(value);
        }

        [HttpGet("TotalGuestCount")]
        public async Task<IActionResult> TotalGuestCount()
        {
            var value = await _context.Reservations.SumAsync(x=> x.CountofPeople);
            return Ok(value);
        }
    }
}
