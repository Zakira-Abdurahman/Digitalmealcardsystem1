namespace DigitalMealCardSystem.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string DigitalID { get; set; }
        public bool IsOptedOut { get; set; }
        public decimal Balance { get; set; }
        public ICollection<Meal> Meals { get; set; }
        public ICollection<Allowance> Allowances { get; set; }

    }
}
