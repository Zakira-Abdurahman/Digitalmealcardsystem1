using DigitalMealCardSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DigitalMealCardSystem.Data
{
    public class MealCardContext : DbContext
    {



        public MealCardContext(DbContextOptions<MealCardContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Allowance> Allowances { get; set; }
    }
}
