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
    [Route("api/customers/{customerId}/bills")]
    public class BillsController : ControllerBase
    {
        private readonly ISPContext _context;
        private readonly IMapper _mapper;

        public BillsController(ISPContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetBills(int customerId)
        {
            var bills = _context.Bills.Where(b => b.CustomerId == customerId).ToList();
            return Ok(_mapper.Map<List<BillReadDto>>(bills));
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(int customerId, BillCreateDto dto)
        {
            var bill = _mapper.Map<Bill>(dto);
            bill.CustomerId = customerId;

            _context.Bills.Add(bill);
            _context.SaveChanges();
            return Ok(_mapper.Map<BillReadDto>(bill));
        }
    }
}
