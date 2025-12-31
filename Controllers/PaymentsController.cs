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
    [Route("api/payments")]
    public class PaymentsController : ControllerBase
    {
        private readonly ISPContext _context;
        private readonly IMapper _mapper;

        public PaymentsController(ISPContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var payment = _context.Payments.Find(id);
            if (payment == null) return NotFound();
            return Ok(_mapper.Map<PaymentReadDto>(payment));
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(PaymentCreateDto dto)
        {
            var payment = _mapper.Map<Payment>(dto);
            _context.Payments.Add(payment);
            _context.SaveChanges();
            return Ok(_mapper.Map<PaymentReadDto>(payment));
        }
    }
    }
