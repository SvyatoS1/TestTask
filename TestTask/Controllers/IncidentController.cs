using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestTask.Context;
using TestTask.Models;
using TestTask.Requests;

namespace TestTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidentController : ControllerBase
    {
        private readonly AppDbContext _context;

        public IncidentController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateIncident([FromBody] IncidentRequest request)
        {
            var account = await _context.Accounts
                .Include(a => a.Contacts)
                .FirstOrDefaultAsync(a => a.Name == request.AccountName);

            if (account == null)
            {
                return NotFound("Account not found");
            }

            var contact = await _context.Contacts.FirstOrDefaultAsync(c => c.Email == request.ContactEmail);

            if (contact == null)
            {
                contact = new Contact
                {
                    FirstName = request.ContactFirstName,
                    LastName = request.ContactLastName,
                    Email = request.ContactEmail,
                    Account = account
                };
                _context.Contacts.Add(contact);
            }
            else
            {
                contact.FirstName = request.ContactFirstName;
                contact.LastName = request.ContactLastName;
                if (contact.Account == null || contact.Account.Id != account.Id)
                {
                    contact.Account = account;
                }
            }

            var incident = new Incident
            {
                Name = Guid.NewGuid().ToString(),
                Description = request.IncidentDescription,
                Accounts = new List<Account> { account }
            };

            _context.Incidents.Add(incident);
            await _context.SaveChangesAsync();

            return Ok(incident);
        }
    }
}
