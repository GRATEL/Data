using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using api.Models;

namespace Name.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private static List<Person> persons = new List<Person>();
        private static int currentId = 1;

        [HttpPost]
        public IActionResult CreatePerson([FromBody] Person person)
        {
            if (string.IsNullOrWhiteSpace(person.FirstName) || string.IsNullOrWhiteSpace(person.LastName))
            {
                return BadRequest("First name and last name are required.");
            }

            person.Id = currentId++;
            persons.Add(person);

            return CreatedAtAction(nameof(GetPersonById), new { id = person.Id }, person);
        }

        [HttpGet("{id}")]
        public IActionResult GetPersonById(int id)
        {
            var person = persons.FirstOrDefault(p => p.Id == id);
            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }
    }
}

