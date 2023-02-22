using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreKamp.Api.DataAccessLayer;

namespace AspNetCoreKamp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeApiController : ControllerBase
    {
        private readonly Context _context = new();

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var value = _context.Employees.ToList();
            return await Task.FromResult(Ok(value));
        }

        [HttpPost]
        public async Task<IActionResult> EmployeeAdd([FromBody] Employee entity)
        {
            if (entity == null) return BadRequest();
            await _context.Employees.AddAsync(entity);
            await _context.SaveChangesAsync();
            return Ok(entity);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee != null)
            {
                return Ok(employee);
            }
            return NotFound();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
                return Ok("Silme işlemi başarılı.");

            }
            else
            {
                return NotFound($"Girilen id{id} ile eşleşme bulunamadı.");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateEmployee(Employee entity, int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee != null)
            {
                employee.Name = entity.Name; 
                _context.Update(employee);
                await _context.SaveChangesAsync();
                return Ok("Güncelleme başarılı bir şekilde gerçekleşti.");
            }
            else
            {
                return NotFound($"Girilen id{id} ile eşleşme bulunamadı.");
            }
        }
    }
}
