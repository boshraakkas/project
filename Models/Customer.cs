using System.ComponentModel.DataAnnotations;

namespace Assignment2.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; } = string.Empty;

        public string? Email { get; set; }
        public string? Phone { get; set; }

        // كل عميل يمكن أن يكون لديه عدة اشتراكات وفواتير
        public ICollection<Subscription> Subscriptions { get; set; } = new List<Subscription>();
        public ICollection<Bill> Bills { get; set; } = new List<Bill>();
    }
}
