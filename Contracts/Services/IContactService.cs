using System.Collections.Generic;
using Contracts.Dto.Responses;
using Contracts.Dto.Requests;
using System.Threading.Tasks;

namespace Contracts.Services
{
    public interface IContactService
    {
        public Task<ClientResponse<ContactDto>> CreateContact(CreateContactDto contactDto);

        Task<ClientResponse<ContactDto>> GetContactById(long ID);

        Task<ClientResponse<bool>> DeleteContactById(long ID);

        public Task<ClientResponse<ContactDto>> UpdateContact(long ID,  UpdateContactDto updateDto);

        public Task<ClientResponse<List<ContactDto>>> GetContactsByLocation(string locationParam, long locationID, PaginationDto pagination);

        public Task<ClientResponse<List<ContactDto>>> GetContactsByMail(string mailParam, PaginationDto pagination);

        public Task<ClientResponse<List<ContactDto>>> GetContactsByPhone(PhoneRequestDto phoneDto);

    }
}
