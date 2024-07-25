namespace DigitalMealCardSystem.Models
{
    public class Meal
    {
        public int MealID { get; set; }
        public int StudentID { get; set; }
        public DateTime MealDate { get; set; }
        public Student Student { get; set; }
    }
}
