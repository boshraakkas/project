using Assignment2.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment2.Data
{
    public class ISPContext: DbContext
    {

        public ISPContext(DbContextOptions<ISPContext> options) : base(options) { }

        // جداول قاعدة البيانات
        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<ServicePlan> ServicePlans => Set<ServicePlan>();
        public DbSet<Subscription> Subscriptions => Set<Subscription>();
        public DbSet<Hardware> Hardwares => Set<Hardware>();
        public DbSet<Ticket> Tickets => Set<Ticket>();
        public DbSet<Bill> Bills => Set<Bill>();
        public DbSet<Payment> Payments => Set<Payment>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // تعريف العلاقات بين الجداول

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.HasMany(c => c.Subscriptions).WithOne(s => s.Customer).HasForeignKey(s => s.CustomerId);
                entity.HasMany(c => c.Bills).WithOne(b => b.Customer).HasForeignKey(b => b.CustomerId);
            });

            modelBuilder.Entity<ServicePlan>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.HasMany(p => p.Subscriptions).WithOne(s => s.ServicePlan).HasForeignKey(s => s.ServicePlanId);
            });

            modelBuilder.Entity<Subscription>(entity =>
            {
                entity.HasKey(s => s.Id);
                entity.HasMany(s => s.Hardwares).WithOne(h => h.Subscription).HasForeignKey(h => h.SubscriptionId);
                entity.HasMany(s => s.Tickets).WithOne(t => t.Subscription).HasForeignKey(t => t.SubscriptionId);
            });

            modelBuilder.Entity<Bill>(entity =>
            {
                entity.HasKey(b => b.Id);
                entity.HasOne(b => b.Payment).WithOne(p => p.Bill).HasForeignKey<Payment>(p => p.BillId);
            });
        }
    }
}
