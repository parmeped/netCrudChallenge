using Contracts.Dto.Requests;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Contracts.Dto.Responses
{
    public class ContactDto
    {
        public uint ID { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
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

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<PhoneDto> Phones { get; set; }
    }
}
