using DemoWebAPIforstd.Data;
using DemoWebAPIforstd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoWebAPIforstd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly EnrollDbContextcs _context;
        public StudentController(EnrollDbContextcs context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IEnumerable<Students>> Get()
        {
            return await _context.Student.ToListAsync();
        }
        [HttpGet("id")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var tn = await _context.Student.FindAsync(id);
            return tn == null ? NotFound() : Ok(tn);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreatePET(Students student)
        {
            await _context.Student.AddAsync(student);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = student.stuid }, student);
        }
        [HttpPut("id")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, Students student)
        {
            
            _context.Entry(student).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var stu = await _context.Student.FindAsync(id);
            if (stu == null) return NotFound();

            _context.Student.Remove(stu);
            await _context.SaveChangesAsync();

            return NoContent();

        }
    }
}
