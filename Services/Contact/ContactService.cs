using Contracts.Contact;
using Contracts.Dto.Requests;
using Contracts.Dto.Responses;
using System;
using System.Collections.Generic;
using Contracts.Repository;
using AutoMapper;
using Repository;

namespace Services.Contact
{
    public class ContactService : IContactService
    {        
        private readonly IMapper _mapper;
        private readonly IRepository _repository;

        public ContactService(IMapper mapper, IRepository repository)
        {            
            _mapper = mapper;
            _repository = repository;
        }

        public ContactDto CreateContact(CreateContactDto contactDto)
        {
            throw new NotImplementedException();
        }

        public bool DeleteContactById(uint ID)
        {
            throw new NotImplementedException();
        }

        public ContactDto GetContactById(uint ID)
        {   
            var result = _repository.Cities.Find(ID);
            var contact = _mapper.Map<ContactDto>(result);
            return contact;                       
        }

        public List<ContactDto> GetContactsByLocation(string locationParam, uint locationID, ushort pageNumber, ushort pageLimit)
        {
            throw new NotImplementedException();
        }

        public List<ContactDto> GetContactsByMail(string mailParam, ushort pageNumber, ushort pageLimit)
        {
            throw new NotImplementedException();
        }

        public List<ContactDto> GetContactsByPhone(string prefix, string number, ushort pageNumber, ushort pageLimit)
        {
            throw new NotImplementedException();
        }

        public ContactDto UpdateContactById(UpdateContactDto updateDto)
        {
            throw new NotImplementedException();
        }
    }
}
