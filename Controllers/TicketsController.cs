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
    [Route("api/tickets")]
    public class TicketsController : ControllerBase
    {
        private readonly ISPContext _context;
        private readonly IMapper _mapper;

        public TicketsController(ISPContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var ticket = _context.Tickets.Find(id);
            if (ticket == null) return NotFound();
            return Ok(_mapper.Map<TicketReadDto>(ticket));
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(TicketCreateDto dto)
        {
            var ticket = _mapper.Map<Ticket>(dto);
            _context.Tickets.Add(ticket);
            _context.SaveChanges();
            return Ok(_mapper.Map<TicketReadDto>(ticket));
        }

        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Update(int id, TicketUpdateDto dto)
        {
            var ticket = _context.Tickets.Find(id);
            if (ticket == null) return NotFound();

            _mapper.Map(dto, ticket);
            _context.SaveChanges();
            return NoContent();
        }
    }
    }
