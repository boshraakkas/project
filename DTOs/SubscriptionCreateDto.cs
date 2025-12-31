namespace Assignment2.DTOs
{
    public class SubscriptionCreateDto
    {
        public int CustomerId { get; set; }
        public int ServicePlanId { get; set; }
        public string Status { get; set; } = "Active";
    }
}
