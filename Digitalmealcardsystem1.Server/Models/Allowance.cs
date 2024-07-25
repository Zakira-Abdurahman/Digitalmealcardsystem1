namespace DigitalMealCardSystem.Models
{
    public class Allowance
    {
        public int AllowanceID { get; set; }
        public int StudentID { get; set; }
        public DateTime AllowanceDate { get; set; }
        public decimal Amount { get; set; }
        public Student Student { get; set; }
    }
}
