using DemoWebAPIforstd.Data;
using DemoWebAPIforstd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoWebAPIforstd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly EnrollDbContextcs _context;
        public SubjectController(EnrollDbContextcs context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IEnumerable<Subjectss>> Get()
        {
            return await _context.Subject.ToListAsync();
        }
        [HttpGet("id")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var tn = await _context.Subject.FindAsync(id);
            return tn == null ? NotFound() : Ok(tn);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreatePET(Subjectss subject)
        {
            await _context.Subject.AddAsync(subject);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = subject.id }, subject);
        }
        [HttpPut("id")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, Subjectss subjectss)
        {
        
            _context.Entry(subjectss).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var stu = await _context.Subject.FindAsync(id);
            if (stu == null) return NotFound();

            _context.Subject.Remove(stu);
            await _context.SaveChangesAsync();

            return NoContent();

        }
    }
}
