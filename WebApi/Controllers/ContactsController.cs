using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Contracts.Dto.Responses;
using Contracts.Dto.Requests;
using Contracts.Services;
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
        public async Task<IActionResult> GetContact(long id)
        {
            if (ModelState.IsValid)
            {
                return buildResponse(await _service.GetContactById(id));
            }
            return null;
        }

        // PATCH: api/Contacts/
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchContact(long id, [FromBody]UpdateContactDto updatedContact)
        {            
            if (ModelState.IsValid)
            {
                return buildResponse(await _service.UpdateContact(id, updatedContact));
            }
            return null;
        }

        // POST: api/Contacts        
        [HttpPost]
        public async Task<IActionResult> PostContact([FromBody]CreateContactDto contact)
        {            
            if (ModelState.IsValid)
            {
                return buildResponse(await _service.CreateContact(contact));
            }
            return null;
        }

        // DELETE: api/Contacts/:id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(long id)
        {
            if (ModelState.IsValid)
            {
                return buildResponse(await _service.DeleteContactById(id));
            }
            return null;
        }

        // GET: apiRoute/byMail/:mail
        [HttpGet("byMail/{mail}")]
        public async Task<IActionResult> GetContactListByMail(string mail, [FromBody]PaginationDto pagination)
        {
            if (ModelState.IsValid)
            {
                return buildResponse(await _service.GetContactsByMail(mail, pagination));
            }
            return null;
        }

        // GET: apiRoute/byPhone/        
        [HttpGet("byPhone/")]
        public async Task<IActionResult> GetContactListByPhone(PhoneRequestDto phoneRequest)
        {
            if (ModelState.IsValid)
            {
                return buildResponse(await _service.GetContactsByPhone(phoneRequest));
            }
            return null;
        }

        // GET: apiRoute/byLocation/:searchParam/:id
        [HttpGet("byLocation/{searchParam}/{id}")]
        public async Task<IActionResult> GetContactListByLocation(string searchParam, long id, [FromBody]PaginationDto pagination)
        {   
            if (ModelState.IsValid)
            {   
                return buildResponse(await _service.GetContactsByLocation(searchParam, id, pagination));
            }
            return null;
        }

        private IActionResult buildResponse<T>(ClientResponse<T> result)
        {
            switch (result.Status)
            {
                case HttpStatusCode.OK:
                    return Ok(result.Response);
                case HttpStatusCode.NoContent:
                    return StatusCode(204, result.Message);
                case HttpStatusCode.NotFound:
                    return NotFound(result.Message);
                case HttpStatusCode.InternalServerError:
                    return StatusCode(500,result.Message);
                case HttpStatusCode.BadRequest:                   
                    return BadRequest(result.Message);
                default:
                    return StatusCode(500);
            }
        }
    }
}
