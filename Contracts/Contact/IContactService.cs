using System;
using System.Collections.Generic;
using System.Text;
using Contracts.Dto.Responses;
using Contracts.Dto.Requests;

namespace Contracts.Contact
{
    public interface IContactService
    {
        public ContactDto CreateContact(CreateContactDto contactDto);

        public ContactDto GetContactById(uint ID);

        public bool DeleteContactById(uint ID);

        public ContactDto UpdateContactById(UpdateContactDto updateDto);

        public List<ContactDto> GetContactsByLocation(string locationParam, uint locationID, ushort pageNumber, ushort pageLimit);

        public List<ContactDto> GetContactsByMail(string mailParam, ushort pageNumber, ushort pageLimit);

        public List<ContactDto> GetContactsByPhone(string prefix, string number, ushort pageNumber, ushort pageLimit);

    }
}
