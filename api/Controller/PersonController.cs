using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using api.Models;
using api.Data;

namespace Name.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public PersonController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePerson([FromBody] Person person)
        {
            if (string.IsNullOrWhiteSpace(person.FirstName) || string.IsNullOrWhiteSpace(person.LastName))
            {
                return BadRequest("First name and last name are required.");
            }

            _context.Persons.Add(person);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPersonById), new { id = person.Id }, person);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPersonById(int id)
        {
            var person = await _context.Persons.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }
    }

}

