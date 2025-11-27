using ApiProjectKamp.WebApi.Context;
using ApiProjectKamp.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjectKamp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeTasksController : ControllerBase
    {
        private readonly ApiContext _context;

        public EmployeeTasksController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult EmployeeTaskList()
        {
            var values = _context.EmployeeTasks.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateEmployeeTask(EmployeeTask employeeTask)
        {
            _context.EmployeeTasks.Add(employeeTask);
            _context.SaveChanges();
            return Ok("Ekleme işlemi başarılı");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployeeTask(int id)
        {
            var result = _context.EmployeeTasks.Find(id);
            _context.EmployeeTasks.Remove(result);
            _context.SaveChanges();
            return Ok("Silme işlemi başarılı.");
        }

        [HttpGet("GetEmployeeTask/{id}")]
        public IActionResult GetEmployeeTask(int id)
        {
            var values = _context.EmployeeTasks.Find(id);
            return Ok(values);
        }

        [HttpPut]
        public IActionResult UpdateEmployeeTask(EmployeeTask employeeTask)
        {
            _context.EmployeeTasks.Update(employeeTask);
            _context.SaveChanges();
            return Ok("Güncelleme işlemi başarılı.");
        }
    }
}
