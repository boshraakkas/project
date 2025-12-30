namespace Assignment2.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public int SubscriptionId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string Status { get; set; } = "Open"; // Open, InProgress, Closed
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public Subscription? Subscription { get; set; }
    }
}
