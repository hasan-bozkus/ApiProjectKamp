using ApiProjectKamp.WebApi.Context;
using ApiProjectKamp.WebApi.Dtos.NotificationDtos;
using ApiProjectKamp.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ApiProjectKamp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public NotificationsController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> NotificationList()
        {
            var values = _mapper.Map<List<ResultNotificationDto>>(await _context.Notifications.ToListAsync());
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNotification(CreateNotificationDto createNotificationDto)
        {
            var result = _mapper.Map<Notification>(createNotificationDto);
            await _context.Notifications.AddAsync(result);
            await _context.SaveChangesAsync();
            return Ok("Kategori ekleme işlemi başarılı");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteNotification(int id)
        {
            var result = _context.Notifications.Find(id);
            _context.Notifications.Remove(result);
            _context.SaveChanges();
            return Ok("Kategori silme işlemi başarılı.");
        }

        [HttpGet("GetNotification")]
        public async Task<IActionResult> GetNotification(int id)
        {
            var values = _mapper.Map<GetNotificationByIdDto>(await _context.Notifications.FindAsync(id));
            return Ok(values);
        }

        [HttpPut]
        public IActionResult UpdateNotification(UpdateNotificationDto updateNotificationDto)
        {
            var result = _mapper.Map<Notification>(updateNotificationDto);
            _context.Notifications.Update(result);
            _context.SaveChanges();
            return Ok("Kategori güncelleme işlemi başarılı.");
        }
    }
}
