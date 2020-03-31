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
                var contact = new Mo.Contact
                {
                    Name = contactDto.Name,
                    BirthDate = contactDto.BirthDate,
                    StreetName = contactDto.StreetName,
                    StreetNumber = contactDto.StreetNumber,
                    CompanyID = contactDto.CompanyID,
                    CityID = contactDto.CityID,
                    ProfileImage = contactDto.ProfileImage,
                    Email = contactDto.Email
                };
                var today = DateTime.Now;
                contact.CreatedAt = today;
                _repository.Contacts.Add(contact);
                //foreach (Mo.Phone p in savedEntity.Phones)
                //{
                //    p.CreatedAt = today;
                //    p.ContactID = savedEntity.ID;
                //}
                await _repository.SaveChangesAsync();
                return null;
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

        public async Task<List<ContactDto>> GetContactsByPhone(PhoneRequestDto request)
        {
            var phones = await _repository.Phones
                                  .Where(p => p.Prefix.Contains(request.Prefix) && p.Number.Contains(request.Number))                                  
                                  .Skip((request.Pagination.Page - 1) * request.Pagination.Limit).Take(request.Pagination.Limit)
                                  .ToListAsync();
            
            // Distinct contacts given that the above returns them all.
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

        // TODO: Works great for everything, except when passing less phones than before and when more phones than before.
        public async Task<ContactDto> UpdateContact(UpdateContactDto updateDto)
        {    
            try
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
            catch (Exception ex)
            {
                return null;
            }
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
            contact.CityID = updatedContact.CityID;
            contact.CompanyID = updatedContact.CompanyID;
            contact.ProfileImage = updatedContact.ProfileImage;
            contact.Name = updatedContact.Name;
            contact.Email = updatedContact.Email;
            contact.StreetName = updatedContact.StreetName;
            contact.StreetNumber = updatedContact.StreetNumber;
            contact.BirthDate = updatedContact.BirthDate;
            var updatedPhones = new List<Mo.Phone>();
            foreach(PhoneDto p in updatedContact.Phones)
            {
                updatedPhones.Add(_mapper.Map<Mo.Phone>(p));
            }
            contact.Phones = updatedPhones;            
            contact.UpdatedAt = DateTime.Now;
        }
    }
}
