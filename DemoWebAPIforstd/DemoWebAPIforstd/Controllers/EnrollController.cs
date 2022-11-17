using DemoWebAPIforstd.Data;
using DemoWebAPIforstd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoWebAPIforstd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollController : ControllerBase
    {
        private readonly EnrollDbContextcs _context;
        public EnrollController(EnrollDbContextcs context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IEnumerable<Enrolls>> Get()
        {
            return await _context.Enroll.ToListAsync();
        }
  
        [HttpGet("id")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var en = await _context.Enroll.FindAsync(id);
            return en == null ? NotFound() : Ok(en);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(Enrolls enroll)
        {
            await _context.Enroll.AddAsync(enroll);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = enroll.enid }, enroll);
        }
        [HttpPut("id")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, Enrolls enroll)
        {
            
            _context.Entry(enroll).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var stu = await _context.Enroll.FindAsync(id);
            if (stu == null) return NotFound();

            _context.Enroll.Remove(stu);
            await _context.SaveChangesAsync();

            return NoContent();

        }
    }
}

