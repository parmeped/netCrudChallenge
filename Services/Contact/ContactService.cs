using Contracts.Contact;
using Contracts.Dto.Requests;
using Contracts.Dto.Responses;
using System;
using System.Collections.Generic;
using Contracts.Repository;
using AutoMapper;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Entities.Models;

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

        public async Task<bool> DeleteContactById(uint ID)
        {
            try
            {
                var contact = await _repository.Contacts.FindAsync(ID);
                _repository.Contacts.Remove(contact);
                await _repository.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        // TODO: Work on exceptions.
        public async Task<ContactDto> GetContactById(uint ID)
        {
            try
            {

                // TODO: Fix this into a single query.
                var contact = await _repository.Contacts.FindAsync(ID);
                var company = await _repository.Companies.FindAsync(contact.CompanyID);
                var city = await _repository.Cities.FindAsync(contact.CityID);
                var state = await _repository.States.FindAsync(city.StateID);
                var phones = await _repository.Phones.Where(p => p.ContactID == ID).ToListAsync();

                var result = _mapper.Map<ContactDto>(contact);                
                return result;                       

            } 
            catch(Exception ex)
            {
                return null;
            }
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
