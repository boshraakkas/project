using System.Net.Sockets;

namespace Assignment2.Models
{
    public class Subscription
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int ServicePlanId { get; set; }
        public string Status { get; set; } = "Active"; // Active, Suspended, Cancelled
        public DateTime StartDate { get; set; } = DateTime.UtcNow;
        public DateTime? EndDate { get; set; }

        public Customer? Customer { get; set; }
        public ServicePlan? ServicePlan { get; set; }

        public ICollection<Hardware> Hardwares { get; set; } = new List<Hardware>();
        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}
