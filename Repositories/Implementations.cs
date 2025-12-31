
using Assignment2.Data;
using Assignment2.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ISPContext _context;
        public CustomerRepository(ISPContext context) => _context = context;

        public async Task AddAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var c = await _context.Customers.FindAsync(id);
            if (c != null)
            {
                _context.Customers.Remove(c);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Customer>> GetAllAsync() =>
            await _context.Customers.Include(c => c.Subscriptions).ToListAsync();

        public async Task<Customer?> GetByIdAsync(int id) =>
            await _context.Customers.Include(c => c.Subscriptions).FirstOrDefaultAsync(c => c.Id == id);

        public async Task UpdateAsync(Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }

    public class ServicePlanRepository : IServicePlanRepository
    {
        private readonly ISPContext _context;
        public ServicePlanRepository(ISPContext context) => _context = context;

        public async Task AddAsync(ServicePlan plan)
        {
            await _context.ServicePlans.AddAsync(plan);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ServicePlan>> GetAllAsync() => await _context.ServicePlans.ToListAsync();
        public async Task<ServicePlan?> GetByIdAsync(int id) => await _context.ServicePlans.FindAsync(id);
    }

    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly ISPContext _context;
        public SubscriptionRepository(ISPContext context) => _context = context;

        public async Task AddAsync(Subscription s)
        {
            await _context.Subscriptions.AddAsync(s);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Subscription>> GetAllAsync() =>
            await _context.Subscriptions.Include(s => s.Customer).Include(s => s.ServicePlan).ToListAsync();

        public async Task<Subscription?> GetByIdAsync(int id) => await _context.Subscriptions.FindAsync(id);
    }

    public class HardwareRepository : IHardwareRepository
    {
        private readonly ISPContext _context;
        public HardwareRepository(ISPContext context) => _context = context;

        public async Task AddAsync(Hardware h)
        {
            await _context.Hardwares.AddAsync(h);
            await _context.SaveChangesAsync();
        }
    }

    public class TicketRepository : ITicketRepository
    {
        private readonly ISPContext _context;
        public TicketRepository(ISPContext context) => _context = context;

        public async Task AddAsync(Ticket t)
        {
            await _context.Tickets.AddAsync(t);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Ticket>> GetAllAsync() =>
            await _context.Tickets.Include(t => t.Subscription).ToListAsync();

        public async Task UpdateAsync(Ticket t)
        {
            _context.Entry(t).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }

    public class BillRepository : IBillRepository
    {
        private readonly ISPContext _context;
        public BillRepository(ISPContext context) => _context = context;

        public async Task AddAsync(Bill b)
        {
            await _context.Bills.AddAsync(b);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Bill>> GetAllAsync() =>
            await _context.Bills.Include(b => b.Customer).ToListAsync();
    }
}
