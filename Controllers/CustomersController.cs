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
    [Route("api/customers")]
    public class CustomersController : ControllerBase
    {
        private readonly ISPContext _context;
        private readonly IMapper _mapper;

        public CustomersController(ISPContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/customers
        [HttpGet]
        public IActionResult GetAll()
        {
            var customers = _context.Customers.ToList();
            return Ok(_mapper.Map<List<CustomerReadDto>>(customers));
        }

        // GET: api/customers/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var customer = _context.Customers.Find(id);
            if (customer == null) return NotFound();
            return Ok(_mapper.Map<CustomerReadDto>(customer));
        }

        // POST: api/customers
        [HttpPost]
        [Authorize]
        public IActionResult Create(CustomerCreateDto dto)
        {
            var customer = _mapper.Map<Customer>(dto);
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return Ok(_mapper.Map<CustomerReadDto>(customer));
        }

        // PUT: api/customers/5
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Update(int id, CustomerUpdateDto dto)
        {
            var customer = _context.Customers.Find(id);
            if (customer == null) return NotFound();

            _mapper.Map(dto, customer);
            _context.SaveChanges();
            return NoContent();
        }

        // DELETE: api/customers/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id)
        {
            var customer = _context.Customers.Find(id);
            if (customer == null) return NotFound();

            _context.Customers.Remove(customer);
            _context.SaveChanges();
            return NoContent();
        }
    }
    }
