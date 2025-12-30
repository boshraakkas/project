namespace Assignment2.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public int BillId { get; set; }
        public DateTime PaidAt { get; set; } = DateTime.UtcNow;
        public decimal PaidAmount { get; set; }
        public string? Method { get; set; }

        public Bill? Bill { get; set; }
    }
}
