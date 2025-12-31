using Assignment2.Models;
using Assignment2.Models;

namespace Assignment.Repositories
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<Customer?> GetByIdAsync(int id);
        Task AddAsync(Customer customer);
        Task UpdateAsync(Customer customer);
        Task DeleteAsync(int id);
    }

    public interface IServicePlanRepository
    {
        Task<IEnumerable<ServicePlan>> GetAllAsync();
        Task<ServicePlan?> GetByIdAsync(int id);
        Task AddAsync(ServicePlan plan);
    }

    public interface ISubscriptionRepository
    {
        Task<IEnumerable<Subscription>> GetAllAsync();
        Task<Subscription?> GetByIdAsync(int id);
        Task AddAsync(Subscription s);
    }

    public interface IHardwareRepository
    {
        Task AddAsync(Hardware h);
    }

    public interface ITicketRepository
    {
        Task<IEnumerable<Ticket>> GetAllAsync();
        Task AddAsync(Ticket t);
        Task UpdateAsync(Ticket t);
    }

    public interface IBillRepository
    {
        Task<IEnumerable<Bill>> GetAllAsync();
        Task AddAsync(Bill b);
    }
}
