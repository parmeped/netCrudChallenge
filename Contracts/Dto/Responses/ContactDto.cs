using Contracts.Dto.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contracts.Dto.Responses
{
    public class ContactDto
    {
        public uint ID { get; set; }
        public string Name { get; set; }
        public uint CompanyID { get; set; }
        public string CompanyName { get; set; }
        public string ProfileImage { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string StreetName { get; set; }
        public ushort StreetNumber { get; set; }
        public uint StateID { get; set; }       
        public string StateName { get; set; }
        public uint CityID { get; set; }
        public string CityName { get; set; }
        public List<PhoneDto> Phones { get; set; }
    }
}
