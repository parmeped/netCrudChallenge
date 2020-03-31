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
using Mo = Entities.Models;
using static MoreLinq.Extensions.DistinctByExtension;



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

        public async Task<ContactDto> CreateContact(CreateContactDto contactDto)
        {
            try
            {
                var contact = _mapper.Map<Mo.Contact>(contactDto);
                var today = DateTime.Now;
                contact.CreatedAt = today;
                var savedEntity = _repository.Contacts.Add(contact);
                //foreach (Mo.Phone p in savedEntity.Phones)
                //{
                //    p.CreatedAt = today;
                //    p.ContactID = savedEntity.ID;
                //}
                await _repository.SaveChangesAsync();
                return _mapper.Map<ContactDto>(savedEntity);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> DeleteContactById(long ID)
        {
            try
            {
                var contact = await _repository.Contacts.FirstOrDefaultAsync(x => x.ID == ID);
                if (contact != null)
                {
                    _repository.Contacts.Remove(contact);
                    await _repository.SaveChangesAsync();
                    return true;
                }                
                return false;                
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        // TODO: Work on exceptions.
        public async Task<ContactDto> GetContactById(long ID)
        {
            try
            {               

                // TODO: Fix this into a single query.
                var contact = await _repository.Contacts.FirstOrDefaultAsync(x => x.ID == ID);
                var company = await _repository.Companies.FirstOrDefaultAsync(x => x.ID == contact.CompanyID);
                var city = await _repository.Cities.FirstOrDefaultAsync(x => x.ID == contact.CityID);
                var state = await _repository.States.FirstOrDefaultAsync(x => x.ID == city.StateID);
                var phones = await _repository.Phones.Where(p => p.ContactID == ID).ToListAsync();

                var result = _mapper.Map<ContactDto>(contact);                
                return result;                       

            } 
            catch(Exception ex)
            {
                return null;
            }
        }


        public async Task<List<ContactDto>> GetContactsByLocation(string locationParam, long locationID, PaginationDto pagination)
        {
            var contacts = await getContactsByLocationParam(locationParam, locationID);

            return await getContactsByList(contacts);           
        }

        public async Task<List<ContactDto>> GetContactsByMail(string mailParam, PaginationDto pagination)
        {            
            var contacts = await _repository.Contacts
                                  .Where(c => c.Email.Contains(mailParam)).OrderBy(x => x.ID)
                                  .Skip((pagination.Page - 1) * pagination.Limit).Take(pagination.Limit)
                                  .ToListAsync();            
            return await getContactsByList(contacts);
        }

        public async Task<List<ContactDto>> GetContactsByPhone(PaginationDto pagination, string prefix = "", string number = "")
        {
            var phones = await _repository.Phones                                  
                                  .Where(p => p.Prefix.Contains(prefix.Trim()) && p.Number.Contains(number.Trim()))                                  
                                  .Skip((pagination.Page - 1) * pagination.Limit).Take(pagination.Limit)
                                  .ToListAsync();
            
            // Distinct contacts, given that the above returns them all.
            if (phones != null && phones.Count > 0)
            {
                var phonesDistinct = phones.DistinctBy(p => p.ContactID);
                var result = new List<ContactDto>();
                foreach (Mo.Phone pho in phonesDistinct)
                {
                    var c = await GetContactById(pho.ContactID);
                    result.Add(c);
                }
                return result;
            }
            return null;
        }

        public async Task<ContactDto> UpdateContact(UpdateContactDto updateDto)
        {            
            var contact = await _repository.Contacts.FirstOrDefaultAsync(x => x.ID == updateDto.ID);
            if (contact != null)
            {
                // TODO: can this use automapper?
                updateContactMap(ref contact, updateDto);
                await _repository.SaveChangesAsync();
                return await GetContactById(contact.ID);
            }
            return null;
        }

        private async Task<List<Mo.Contact>> getContactsByLocationParam(string param, long paramID)
        {            
            if (param.ToUpper().Contains("COMPANY"))
            {
                return await _repository.Contacts
                             .Where(c => c.CompanyID == paramID)
                             .ToListAsync();
            }
            if (param.ToUpper().Contains("CITY"))
            {
                return await _repository.Contacts
                             .Where(c => c.CityID == paramID)
                             .ToListAsync();
            }
            return null;
        }

        private async Task<List<ContactDto>> getContactsByList(List<Mo.Contact> contacts)
        {
            if (contacts != null && contacts.Count > 0)
            {
                var result = new List<ContactDto>();
                foreach (Mo.Contact co in contacts)
                {
                    var c = await GetContactById(co.ID);
                    result.Add(c);
                }
                return result;
            }
            return null;
        }

        private void updateContactMap(ref Mo.Contact contact, UpdateContactDto updatedContact)
        {
            contact.UpdatedAt = DateTime.Now;
            contact.CityID = updatedContact.CityID;
            contact.CompanyID = updatedContact.CompanyID;
            contact.ProfileImage = updatedContact.ProfileImage;
            contact.Name = updatedContact.Name;
            contact.StreetName = updatedContact.StreetName;
            contact.StreetNumber = updatedContact.StreetNumber;
            contact.BirthDate = updatedContact.BirthDate;
            var updatedPhones = new List<Mo.Phone>();
            foreach(PhoneDto p in updatedContact.Phones)
            {
                updatedPhones.Add(_mapper.Map<Mo.Phone>(p));
            }
            contact.Phones = updatedPhones;
        }
    }
}
