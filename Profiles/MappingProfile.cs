using Assignment2.DTOs;
using Assignment2.Models;
using AutoMapper;

namespace Assignment2.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            // ================= Customer =================
            CreateMap<Customer, CustomerReadDto>();
            CreateMap<CustomerCreateDto, Customer>();
            CreateMap<CustomerUpdateDto, Customer>();

            // ================= ServicePlan =================
            CreateMap<ServicePlan, ServicePlanReadDto>();
            CreateMap<ServicePlanCreateDto, ServicePlan>();
            CreateMap<ServicePlanUpdateDto, ServicePlan>();

            // ================= Subscription =================
            CreateMap<Subscription, SubscriptionReadDto>();
            CreateMap<SubscriptionCreateDto, Subscription>();
            CreateMap<SubscriptionUpdateDto, Subscription>();

            // ================= Ticket =================
            CreateMap<Ticket, TicketReadDto>();
            CreateMap<TicketCreateDto, Ticket>();
            CreateMap<TicketUpdateDto, Ticket>();

            // ================= Bill =================
            CreateMap<Bill, BillReadDto>();
            CreateMap<BillCreateDto, Bill>();
            CreateMap<BillUpdateDto, Bill>();

            // ================= Payment =================
            CreateMap<Payment, PaymentReadDto>();
            CreateMap<PaymentCreateDto, Payment>();
        }
    }
}
