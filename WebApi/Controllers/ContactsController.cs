using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Contracts.Dto.Responses;
using Contracts.Dto.Requests;
using Contracts.Contact;
using System.Net;

namespace WebApi.Controllers
{
    [Route("api/v1/contacts/")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _service;

        public ContactsController(IContactService service)
        {
            _service = service;
        }

        // GET: apiRoute/:id
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ContactDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetContact(uint id)
        {
            return null;
        }

        //// PATCH: api/Contacts/:id
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutContact(uint id, UpdateContactDto updatedContact)
        //{
            // TODO: would this be neccesary? We do already receive the ID. 
            //if (id != updatedContact.ID)
            //{
            //    return BadRequest();
            //}
                        
        //    try
        //    {
        //        await _service.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ContactExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Contacts        
        //[HttpPost]
        //public async Task<ActionResult<Contact>> PostContact(Contact contact)
        //{
        //    _service.Contacts.Add(contact);
        //    await _service.SaveChangesAsync();

        //    return CreatedAtAction("GetContact", new { id = contact.ID }, contact);
        //}

        //// DELETE: api/Contacts/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Contact>> DeleteContact(uint id)
        //{
        //    var contact = await _service.Contacts.FindAsync(id);
        //    if (contact == null)
        //    {
        //        return NotFound();
        //    }

        //    _service.Contacts.Remove(contact);
        //    await _service.SaveChangesAsync();

        //    return contact;
        //}

        //private bool ContactExists(uint id)
        //{
        //    return _service.Contacts.Any(e => e.ID == id);
        //}
    }
}
