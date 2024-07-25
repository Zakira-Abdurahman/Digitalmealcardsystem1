using DigitalMealCardSystem.Data;
using DigitalMealCardSystem.Models;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace DigitalMealCardSystem.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AllowancesController : ControllerBase
    {
        private readonly MealCardContext _context;

        public AllowancesController(MealCardContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Allowance>>> GetAllowances()
        {
            return await _context.Allowances.Include(a => a.Student).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Allowance>> GetAllowance(int id)
        {
            var allowance = await _context.Allowances.Include(a => a.Student).FirstOrDefaultAsync(a => a.AllowanceID == id);

            if (allowance == null)
            {
                return NotFound();
            }

            return allowance;
        }

        [HttpPost]
        public async Task<ActionResult<Allowance>> PostAllowance(Allowance allowance)
        {
            _context.Allowances.Add(allowance);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAllowance), new { id = allowance.AllowanceID }, allowance);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAllowance(int id, Allowance allowance)
        {
            if (id != allowance.AllowanceID)
            {
                return BadRequest();
            }

            _context.Entry(allowance).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AllowanceExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAllowance(int id)
        {
            var allowance = await _context.Allowances.FindAsync(id);
            if (allowance == null)
            {
                return NotFound();
            }

            _context.Allowances.Remove(allowance);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AllowanceExists(int id)
        {
            return _context.Allowances.Any(e => e.AllowanceID == id);
        }
    }

}


