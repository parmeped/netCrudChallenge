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
using H = Services.Helpers.Helpers;
using E = Services.Errors.Errors;


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

        public async Task<ClientResponse<ContactDto>> CreateContact(CreateContactDto contactDto)
        {            
            var response = new ClientResponse<ContactDto>();
            try
            {
                if (contactDto.BirthDate > DateTime.Now)
                {
                    response.Message = E.ErrHigherBirthDate;
                    response.Status = System.Net.HttpStatusCode.BadRequest;
                    return response;
                }
                if (await validateContactNotExists(contactDto.Email, contactDto.Name))
                {
                    response.Message = E.ErrContactAlreadyExists;
                    response.Status = System.Net.HttpStatusCode.BadRequest;
                    return response;
                }
                if (await validateCityAndCompany(contactDto.CityID, contactDto.CompanyID))
                {
                    
                    var contact = new Mo.Contact
                    {
                        Name = H.UppercaseFirst(contactDto.Name),
                        BirthDate = contactDto.BirthDate,
                        StreetName = H.UppercaseFirst(contactDto.StreetName),
                        StreetNumber = contactDto.StreetNumber,
                        CompanyID = contactDto.CompanyID,
                        CityID = contactDto.CityID,
                        ProfileImage = contactDto.ProfileImage,
                        Email = contactDto.Email.ToLower(),
                        Phones = new List<Mo.Phone>(),
                        Active = true
                    };
                
                    contact.CreatedAt = DateTime.Now;
                    foreach (PhoneDto p in contactDto.Phones)
                    {                    
                        contact.Phones.Add(_mapper.Map<Mo.Phone>(p));
                    }
                    _repository.Contacts.Add(contact);

                    await _repository.SaveChangesAsync();
                    return await GetContactById(contact.ID);
                }
                response.Message = E.ErrGeneric;
                response.Status = System.Net.HttpStatusCode.InternalServerError;
                return response;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = System.Net.HttpStatusCode.InternalServerError;
                return response;
            }
        }

        public async Task<bool> DeleteContactById(long ID)
        {            
            try
            {
                var contact = await _repository.Contacts.FirstOrDefaultAsync(x => x.ID == ID && x.Active);                

                // Soft Delete
                if (contact != null)
                {
                    var phones = await _repository.Phones.Where(p => p.ContactID == ID).ToListAsync();
                    contact.Phones = phones;
                    contact.DeletedAt = DateTime.Now;
                    contact.Active = false;
                    if (contact.Phones != null && contact.Phones.Count > 0)
                    {
                        foreach(Mo.Phone p in contact.Phones)
                        {
                            p.DeletedAt = DateTime.Now;
                            p.Active = false;
                        }
                    }
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

        
        public async Task<ClientResponse<ContactDto>> GetContactById(long ID)
        {
            var response = new ClientResponse<ContactDto>();
            try
            {   
                var contact = await _repository.Contacts.FirstOrDefaultAsync(x => x.ID == ID && x.Active);       
                if (contact != null)
                {
                    var company = await _repository.Companies.FirstOrDefaultAsync(x => x.ID == contact.CompanyID && x.Active);                
                    var city = await _repository.Cities.FirstOrDefaultAsync(x => x.ID == contact.CityID && x.Active);                
                    var state = await _repository.States.FirstOrDefaultAsync(x => x.ID == city.StateID && x.Active);
                    var phones = await _repository.Phones.Where(p => p.ContactID == ID && p.Active).ToListAsync();
                    var result = _mapper.Map<ContactDto>(contact);
                    
                    response.Response = result;
                    response.Status = System.Net.HttpStatusCode.OK;
                    return response;
                }
                response.Message = E.ErrContactNotFound;
                response.Status = System.Net.HttpStatusCode.NoContent;
                return response;

            } 
            catch(Exception ex)
            {
                response.Message = ex.Message;
                response.Status = System.Net.HttpStatusCode.InternalServerError;
                return response;
            }
        }


        public async Task<ClientResponse<List<ContactDto>>> GetContactsByLocation(string locationParam, long locationID, PaginationDto pagination)
        {
            var response = new ClientResponse<List<ContactDto>>();
            try
            {  
                pagination ??= new PaginationDto();

                var contacts = await getContactsByLocationParam(locationParam, locationID);

                if (contacts == null)
                {
                    response.Status = System.Net.HttpStatusCode.NoContent;
                    response.Message = E.ErrWrongLocationParameter;
                    return response;
                }
                
                return await getContactsByList(contacts);           
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = System.Net.HttpStatusCode.InternalServerError;
                return response;
            }
        }

        public async Task<ClientResponse<List<ContactDto>>> GetContactsByMail(string mailParam, PaginationDto pagination)
        {
            var response = new ClientResponse<List<ContactDto>>();
            try
            {
                pagination ??= new PaginationDto();

                var contacts = await _repository.Contacts
                                      .Where(c => c.Email.Contains(mailParam) && c.Active).OrderBy(x => x.ID)
                                      .Skip((pagination.Page - 1) * pagination.Limit).Take(pagination.Limit)
                                      .ToListAsync();

                if (contacts == null)
                {
                    response.Status = System.Net.HttpStatusCode.NoContent;
                    response.Message = E.ErrContactNotFound;
                    return response;
                }

                return await getContactsByList(contacts);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = System.Net.HttpStatusCode.InternalServerError;
                return response;
            }
        }

        public async Task<ClientResponse<List<ContactDto>>> GetContactsByPhone(PhoneRequestDto request)
        {
            var response = new ClientResponse<List<ContactDto>>();
            try
            {
                request.Pagination ??= new PaginationDto();
                // If it got up to here, prefix and number should be ints given that they passed the model validation, so we can parse to string
                var phones = await _repository.Phones
                                      .Where(p => p.Active && p.Prefix.Contains(request.Prefix.ToString()) && p.Number.Contains(request.Number.ToString()))     
                                      .Skip((request.Pagination.Page - 1) * request.Pagination.Limit).Take(request.Pagination.Limit)
                                      .ToListAsync();
            
                // Distinct contacts since the above returns them all.
                if (phones != null && phones.Count > 0)
                {
                    var phonesDistinct = phones.DistinctBy(p => p.ContactID);
                    var result = new List<ContactDto>();
                    foreach (Mo.Phone pho in phonesDistinct)
                    {
                        var c = (await GetContactById(pho.ContactID)).Response;
                        result.Add(c);
                    }
                    response.Status = System.Net.HttpStatusCode.OK;
                    response.Response = result;
                    return response;
                }
                response.Status = System.Net.HttpStatusCode.NoContent;
                response.Message = E.ErrNoPhonesFound;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = System.Net.HttpStatusCode.InternalServerError;
                return response;
            }
        }
                
        public async Task<ClientResponse<ContactDto>> UpdateContact(long ID, UpdateContactDto updateDto)
        {
            var response = new ClientResponse<ContactDto>();
            try
            {
                if (updateDto.BirthDate > DateTime.Now)
                {
                    return null;
                }
                var contact = await _repository.Contacts.FirstOrDefaultAsync(x => x.ID == ID && x.Active);
                if (contact == null)
                {
                    return null;                                                        
                }
                if (await validateCityAndCompany(contact.CityID, contact.CompanyID))
                {
                    var phones = await _repository.Phones.Where(x => x.ContactID == contact.ID).ToListAsync();
                    contact.Phones = phones;
                    updateContactMap(ref contact, updateDto);

                    await _repository.SaveChangesAsync();
                    return await GetContactById(contact.ID);
                }
                return null;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = System.Net.HttpStatusCode.InternalServerError;
                return response;
            }
        }

        #region Private methods

        private async Task<List<Mo.Contact>> getContactsByLocationParam(string param, long paramID)
        {            
            if (param.ToUpper().Contains("COMPANY"))
            {
                var location = await _repository.Companies.FirstOrDefaultAsync(x => x.ID == paramID);
                if (location != null)
                {
                    return await _repository.Contacts
                                 .Where(c => c.CompanyID == paramID)
                                 .ToListAsync();
                }
            }
            if (param.ToUpper().Contains("CITY"))
            {
                var location = await _repository.Cities.FirstOrDefaultAsync(x => x.ID == paramID);
                if (location != null)
                {
                    return await _repository.Contacts
                                 .Where(c => c.CityID == paramID)
                                 .ToListAsync();
                }
            }
            return null;
        }

        private async Task<ClientResponse<List<ContactDto>>> getContactsByList(List<Mo.Contact> contacts)
        {
            var response = new ClientResponse<List<ContactDto>>();
            if (contacts != null && contacts.Count > 0)
            {
                var result = new List<ContactDto>();
                foreach (Mo.Contact co in contacts)
                {
                    var c = (await GetContactById(co.ID)).Response;
                    result.Add(c);
                }
                response.Status = System.Net.HttpStatusCode.OK;
                response.Response = result;
                return response;
            }        
            response.Message = E.ErrContactNotFound;
            response.Status = System.Net.HttpStatusCode.NoContent;
            return response;
        }
                
        private void updateContactMap(ref Mo.Contact contact, UpdateContactDto updatedContact)
        {
            contact.CityID = updatedContact.CityID;
            contact.CompanyID = updatedContact.CompanyID;
            contact.ProfileImage = updatedContact.ProfileImage;
            contact.Name = H.UppercaseFirst(updatedContact.Name);
            contact.Email = updatedContact.Email.ToLower();
            contact.StreetName = H.UppercaseFirst(updatedContact.StreetName);
            contact.StreetNumber = updatedContact.StreetNumber;
            contact.BirthDate = updatedContact.BirthDate;

            var phoneIds = new HashSet<long>();            
            foreach(PhoneDto p in updatedContact.Phones)
            {
                // Add only new phones
                if (p.ID == 0)
                {                    
                    contact.Phones.Add(_mapper.Map<Mo.Phone>(p));                
                }
                // keep old valid phones
                if (p.ID > 0)
                {
                    phoneIds.Add(p.ID);
                }
            }                       

            // Soft Delete older phones
            foreach (Mo.Phone p in contact.Phones)
            {
                if (p.ID > 0 && !phoneIds.Contains(p.ID))
                {
                    p.Active = false;
                    p.DeletedAt = DateTime.Now;
                }
                else
                {
                    p.Active = true;
                }
            }
            contact.UpdatedAt = DateTime.Now;
        }

        private async Task<bool> validateCityAndCompany(long cityID, long companyID)
        {
            var company = await _repository.Companies.FirstOrDefaultAsync(x => x.ID == companyID && x.Active);
            if (company == null)
            {
                return false;
            }
            var city = await _repository.Cities.FirstOrDefaultAsync(x => x.ID == cityID && x.Active);
            if (city == null)
            {
                return false;
            }
            return true;
        }

        private async Task<bool> validateContactNotExists(string email, string name)
        {
            var contact = await _repository.Contacts.FirstOrDefaultAsync(x => x.Email == email || x.Name == name);
            return contact != null;
        }

        #endregion region Private methods
    }
}
