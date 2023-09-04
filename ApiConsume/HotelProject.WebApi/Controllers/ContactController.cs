using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public IActionResult InboxListContact()
        {
            var values = _contactService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddContact(Contact contact)
        {
            contact.Date= Convert.ToDateTime(DateTime.Now.ToString());  
            _contactService.TInsert(contact);
            return Ok();
        }
        //[HttpDelete("{id}")]
        //public IActionResult DeleteContact(int id)
        //{
        //    var value = _contactService.TGetByID(id);
        //    if (value != null)
        //    {
        //        _contactService.TDelete(value);
        //        return Ok();

        //    }
        //    return BadRequest();
        //}
        //[HttpPut("UpdateContact")]
        //public IActionResult UpdateContact(Contact contact)
        //{
        //    _contactService.TUpdate(contact);
        //    return Ok();
        //}
        
    }
}
