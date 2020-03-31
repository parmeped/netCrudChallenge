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
        public async Task<ContactDto> GetContact(uint id)
        {
            return await _service.GetContactById(id);
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

        // DELETE: api/Contacts/:id
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteContact(uint id)
        {
            // TODO: This works great but doesn't perform a soft delete
            return await _service.DeleteContactById(id);
        }

        //private bool ContactExists(uint id)
        //{
        //    return _service.Contacts.Any(e => e.ID == id);
        //}
    }
}
