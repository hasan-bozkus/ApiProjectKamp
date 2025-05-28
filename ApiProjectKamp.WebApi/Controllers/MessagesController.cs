using ApiProjectKamp.WebApi.Context;
using ApiProjectKamp.WebApi.Dtos.MessageDtos;
using ApiProjectKamp.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiProjectKamp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public MessagesController(IMapper mapper, ApiContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> MessageList()
        {
            var values = _mapper.Map<List<ResultMessageDto>>(await _context.Messages.ToListAsync());
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMessage(CreateMessageDto createMessageDto)
        {
            var result = _mapper.Map<Message>(createMessageDto);
            await _context.Messages.AddAsync(result);
            await _context.SaveChangesAsync();
            return Ok("Ekleme işlemi başarılı");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMessage(int id)
        {
            var value = await _context.Messages.FindAsync(id);
            _context.Messages.Remove(value);
            await _context.SaveChangesAsync();
            return Ok("Silme işlemi başarılı");
        }

        [HttpGet("GetMessage/{id}")]
        public async Task<IActionResult> GetMessage(int id)
        {
            var value = _mapper.Map<ResultMessageDto>(await _context.Messages.FindAsync(id));
            return Ok(value);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMessage(UpdateMessageDto updateMessageDto)
        {
            var result = _mapper.Map<Message>(updateMessageDto);
            _context.Messages.Update(result);
            await _context.SaveChangesAsync();
            return Ok("Güncelleme işlemi başarılı");
        }

        [HttpGet("MessageListByIsReadFalse")]
        public async Task<IActionResult> MessageListByIsReadFalse()
        {
            var value = await _context.Messages.Where(x => x.IsRead == false).ToListAsync();
            return Ok(value);
        }
    }
}
