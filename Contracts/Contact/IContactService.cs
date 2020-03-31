using System;
using System.Collections.Generic;
using Contracts.Dto.Responses;
using Contracts.Dto.Requests;
using System.Threading.Tasks;

namespace Contracts.Contact
{
    public interface IContactService
    {
        public Task<ContactDto> CreateContact(CreateContactDto contactDto);

        Task<ContactDto> GetContactById(long ID);

        Task<bool> DeleteContactById(long ID);

        public Task<ContactDto> UpdateContact(UpdateContactDto updateDto);

        public Task<List<ContactDto>> GetContactsByLocation(string locationParam, long locationID, PaginationDto pagination);

        public Task<List<ContactDto>> GetContactsByMail(string mailParam, PaginationDto pagination);

        public Task<List<ContactDto>> GetContactsByPhone(PhoneRequestDto phoneDto);

    }
}
