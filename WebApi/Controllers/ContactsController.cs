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

        // PATCH: api/Contacts/
        [HttpPatch()]
        public async Task<ActionResult<ContactDto>> PatchContact([FromBody]UpdateContactDto updatedContact)
        {
            return await _service.UpdateContact(updatedContact);
        }

        // POST: api/Contacts        
        [HttpPost]
        public async Task<ActionResult<ContactDto>> PostContact([FromBody]CreateContactDto contact)
        {
            return await _service.CreateContact(contact);
        }

        // DELETE: api/Contacts/:id
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteContact(uint id)
        {
            // TODO: This works great but doesn't perform a soft delete
            return await _service.DeleteContactById(id);
        }

        // GET: apiRoute/byMail/:mail
        [HttpGet("byMail/{mail}")]
        public async Task<List<ContactDto>> GetContactListByMail(string mail, [FromBody]PaginationDto paginationDto)
        {
            return await _service.GetContactsByMail(mail, paginationDto);
        }

        // GET: apiRoute/byPhone/        
        [HttpGet("byPhone/")]
        public async Task<List<ContactDto>> GetContactListByPhone([FromQuery]string prefix, [FromQuery]string number, [FromBody]PaginationDto paginationDto)
        {
            return await _service.GetContactsByPhone(paginationDto, prefix, number);
        }

        // GET: apiRoute/byLocation/:searchParam/:id
        [HttpGet("byLocation/{searchParam}/{id}")]
        public async Task<List<ContactDto>> GetContactListByLocation(string searchParam, uint id, [FromBody]PaginationDto paginationDto)
        {
            return await _service.GetContactsByLocation(searchParam, id, paginationDto);
        }
    }
}
