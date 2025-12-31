using Assignment2.Data;
using Assignment2.DTOs;
using Assignment2.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Assignment2.Controllers
{
    
        [ApiController]
        [Route("api/serviceplans")]
        public class ServicePlansController : ControllerBase
        {
            private readonly ISPContext _context;
            private readonly IMapper _mapper;

            public ServicePlansController(ISPContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            [HttpGet]
            public IActionResult GetAll()
            {
                return Ok(_mapper.Map<List<ServicePlanReadDto>>(_context.ServicePlans.ToList()));
            }

            [HttpGet("{id}")]
            public IActionResult GetById(int id)
            {
                var plan = _context.ServicePlans.Find(id);
                if (plan == null) return NotFound();
                return Ok(_mapper.Map<ServicePlanReadDto>(plan));
            }

            [HttpPost]
            [Authorize]
            public IActionResult Create(ServicePlanCreateDto dto)
            {
                var plan = _mapper.Map<ServicePlan>(dto);
                _context.ServicePlans.Add(plan);
                _context.SaveChanges();
                return Ok(_mapper.Map<ServicePlanReadDto>(plan));
            }
        }
    
}
