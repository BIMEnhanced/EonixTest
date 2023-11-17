using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonApi.Models;


namespace PersonApi.Controllers
{
    /// <summary>
    /// Person controller to deal with all people interactions
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly AppDbContext _context;

        /// <summary>
        /// Constructor with appdbcontext
        /// </summary>
        /// <param name="context"></param>
        public PersonController(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieval a list of people, with filters on first and last names
        /// </summary>
        /// <param name="firstName">The first name</param>
        /// <param name="lastName">The last name</param>
        /// <returns>A list of people</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetPeople(string firstName = "", string lastName = "")
        {
            var query = _context.Persons.AsQueryable();

            if (!string.IsNullOrWhiteSpace(firstName))
                query = query.Where(p => EF.Functions.Like(p.FirstName, $"%{firstName}%"));

            if (!string.IsNullOrWhiteSpace(lastName))
                query = query.Where(p => EF.Functions.Like(p.LastName, $"%{lastName}%"));

            return await query.ToListAsync();
        }

        /// <summary>
        /// Get a person by his Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPerson(string id)
        {
            var person = await _context.Persons.FindAsync(new Guid(id));

            if (person == null)
                return NotFound();

            return person;
        }

        /// <summary>
        /// Add a new person to the database
        /// </summary>
        /// <param name="person"></param>
        /// <returns>201Created response</returns>
        [HttpPost]
        public async Task<ActionResult<Person>> AddPerson(Person person)
        {
            if (string.IsNullOrWhiteSpace(person.FirstName) || string.IsNullOrWhiteSpace(person.LastName))
                return BadRequest("Both first name and last name are required.");

            _context.Persons.Add(person);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPerson), new { id = person.Id }, person);
        }

        /// <summary>
        /// Update a person
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updatedPerson"></param>
        /// <returns>Code 204</returns>
        [HttpPut()]
        public async Task<IActionResult> UpdatePerson(Person updatedPerson)
        {
            if (!_context.Persons.Any(p => p.Id == updatedPerson.Id))
                return NotFound();

            _context.Entry(updatedPerson).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        /// <summary>
        /// Delete a person by his id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Code 204</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(string id)
        {
            var person = await _context.Persons.FindAsync(new Guid(id));

            if (person == null)
                return NotFound();

            _context.Persons.Remove(person);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
