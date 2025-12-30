namespace Assignment2.Models
{
    public class Hardware
    {
        public int Id { get; set; }
        public string SerialNumber { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int SubscriptionId { get; set; }
        public DateTime AllocatedAt { get; set; } = DateTime.UtcNow;

        public Subscription? Subscription { get; set; }
    }
}
