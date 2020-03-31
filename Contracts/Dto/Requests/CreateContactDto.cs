using Contracts.Dto.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts.Dto.Requests
{
    public class CreateContactDto
    {
        public string Name { get; set; }
        public long CompanyID { get; set; }        
        public string ProfileImage { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string StreetName { get; set; }
        public ushort StreetNumber { get; set; }
        public long CityID { get; set; }        
        public virtual List<PhoneDto> Phones { get; set; }
    }
}
