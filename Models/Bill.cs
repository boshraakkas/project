namespace Assignment2.Models
{
    public class Bill
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime IssueDate { get; set; } = DateTime.UtcNow;
        public DateTime DueDate { get; set; } = DateTime.UtcNow.AddDays(30);
        public decimal Amount { get; set; }
        public bool IsPaid { get; set; }

        public Customer? Customer { get; set; }
        public Payment? Payment { get; set; }
    }
}
