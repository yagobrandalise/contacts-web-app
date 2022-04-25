using ContactsApplication.Services;
using ContactsApplication.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContactsApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly ContactsService _contactsService;
        public ContactController(ContactsService contactsService)
        {
            _contactsService = contactsService; 
        }

        [HttpPost("add-contact")]
        public IActionResult AddContact([FromBody] ContactViewModel contact)
        {
            _contactsService.AddContact(contact);
            return Ok();
        }

        [HttpGet("get-all")]
        public IActionResult GetAll(string? keyword = null)
        {
            var contacts = _contactsService.GetAll(keyword);
            return Ok(contacts);
        }

        [HttpGet("get/{id}")]
        public IActionResult Get(long id)
        {
            var contact = _contactsService.Get(id);
            return Ok(contact);
        }

        [HttpPut("update/{id}")]
        public IActionResult Update(long id, [FromBody] ContactViewModel contact)
        {
            var _contact = _contactsService.Update(id, contact);
            return Ok(_contact);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(long id)
        {
            _contactsService.Delete(id);
            return Ok();
        }

    }
}
