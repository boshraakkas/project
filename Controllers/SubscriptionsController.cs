using Assignment2.Data;
using Assignment2.DTOs;
using Assignment2.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment2.Controllers
{
    [ApiController]
    [Route("api/subscriptions")]
    public class SubscriptionsController : ControllerBase
    {
        private readonly ISPContext _context;
        private readonly IMapper _mapper;

        public SubscriptionsController(ISPContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_mapper.Map<List<SubscriptionReadDto>>(_context.Subscriptions.ToList()));
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(SubscriptionCreateDto dto)
        {
            var sub = _mapper.Map<Subscription>(dto);
            _context.Subscriptions.Add(sub);
            _context.SaveChanges();
            return Ok(_mapper.Map<SubscriptionReadDto>(sub));
        }

        [HttpPut("{id}")]
        [Authorize]
        public IActionResult UpdateStatus(int id, SubscriptionUpdateDto dto)
        {
            var sub = _context.Subscriptions.Find(id);
            if (sub == null) return NotFound();

            _mapper.Map(dto, sub);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
