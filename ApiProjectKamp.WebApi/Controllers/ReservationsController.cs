using ApiProjectKamp.WebApi.Context;
using ApiProjectKamp.WebApi.Dtos.ReservationDtos;
using ApiProjectKamp.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiProjectKamp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public ReservationsController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ReservationList()
        {
            var values = _context.Reservations.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateReservation(CreateReservationDto createReservationDto)
        {
            var value = _mapper.Map<Reservation>(createReservationDto);
            _context.Reservations.Add(value);
            _context.SaveChanges();
            return Ok("Rezervasyon ekleme işlemi başarılı");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteReservation(int id)
        {
            var result = _context.Reservations.Find(id);
            _context.Reservations.Remove(result);
            _context.SaveChanges();
            return Ok("Rezervasyon silme işlemi başarılı.");
        }

        [HttpGet("GetReservation/{id}")]
        public IActionResult GetReservation(int id)
        {
            var values = _context.Reservations.Find(id);
            return Ok(values);
        }

        [HttpPut]
        public IActionResult UpdateReservation(UpdateReservationDto updateReservationDto)
        {
            var result = _mapper.Map<Reservation>(updateReservationDto);
            _context.Reservations.Update(result);
            _context.SaveChanges();
            return Ok("Rezervasyon güncelleme işlemi başarılı.");
        }

        [HttpGet("GetTotalReservationCount")]
        public async Task<IActionResult> GetTotalReservationCount()
        {
            var value = await _context.Reservations.CountAsync();
            return Ok(value);
        }

        [HttpGet("GetTotalCustomerCount")]
        public async Task<IActionResult> GetTotalCustomerCount()
        {
            var value = await _context.Reservations.SumAsync(x => x.CountofPeople);
            return Ok(value);
        }

        [HttpGet("GetPendingReservation")]
        public async Task<IActionResult> GetPendingReservation()
        {
            var value = await _context.Reservations.Where(x => x.ReservationStatus == "Onay Bekliyor").CountAsync();
            return Ok(value);
        }

        [HttpGet("GetApprovedReservation")]
        public async Task<IActionResult> GetApprovedReservation()
        {
            var value = await _context.Reservations.Where(x => x.ReservationStatus == "Onaylandı").CountAsync();
            return Ok(value);
        }

        [HttpGet("GetReservationStats")]
        public async Task<IActionResult> GetReservationStats()
        {
            DateTime today = DateTime.Today;
            DateTime fourMonthsAgo = today.AddMonths(-3);

            // 1. SQL tarafında sadece gruplama ve veri çekme
            var rawData = await _context.Reservations
                .Where(r => r.ReservationDate >= fourMonthsAgo)
                .GroupBy(r => new { r.ReservationDate.Year, r.ReservationDate.Month })
                .Select(g => new
                {
                    g.Key.Year,
                    g.Key.Month,
                    Approved = g.Count(x => x.ReservationStatus == "Onaylandı"),
                    Pending = g.Count(x => x.ReservationStatus == "Onay Bekliyor"),
                    Canceled = g.Count(x => x.ReservationStatus == "İptal Edildi")
                })
                .OrderBy(x => x.Year).ThenBy(x => x.Month)
                .ToListAsync(); // Burada SQL biter, veriler RAM’e alınır

            // 2. Bellekte DTO'ya mapleme + tarih formatlama
            var result = rawData.Select(x => new ReservationChartDto
            {
                Month = new DateTime(x.Year, x.Month, 1).ToString("MMM yyyy"),
                Approved = x.Approved,
                Pending = x.Pending,
                Canceled = x.Canceled
            }).ToList();
            return Ok(result);
        }
    }
}
