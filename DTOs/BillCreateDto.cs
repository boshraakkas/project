namespace Assignment2.DTOs
{
    public class BillCreateDto
    {
        public int CustomerId { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; } = "Unpaid";
    }
}
