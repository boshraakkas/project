namespace Assignment2.DTOs
{
    public class SubscriptionReadDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int ServicePlanId { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
