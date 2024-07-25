using DigitalMealCardSystem.Data;
using DigitalMealCardSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;




namespace DigitalMealCardSystem.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class MealsController : ControllerBase
    {
        private readonly MealCardContext _context;

        public MealsController(MealCardContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Meal>>> GetMeals()
        {
            return await _context.Meals.Include(m => m.Student).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Meal>> GetMeal(int id)
        {
            var meal = await _context.Meals.Include(m => m.Student).FirstOrDefaultAsync(m => m.MealID == id);

            if (meal == null)
            {
                return NotFound();
            }

            return meal;
        }

        [HttpPost]
        public async Task<ActionResult<Meal>> PostMeal(Meal meal)
        {
            _context.Meals.Add(meal);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMeal), new { id = meal.MealID }, meal);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMeal(int id, Meal meal)
        {
            if (id != meal.MealID)
            {
                return BadRequest();
            }

            _context.Entry(meal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MealExists(id))
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
        public async Task<IActionResult> DeleteMeal(int id)
        {
            var meal = await _context.Meals.FindAsync(id);
            if (meal == null)
            {
                return NotFound();
            }

            _context.Meals.Remove(meal);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MealExists(int id)
        {
            return _context.Meals.Any(e => e.MealID == id);
        }
    }

}

