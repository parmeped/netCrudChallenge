using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts.Dto.Requests
{
    public class PhoneDto
    {
        public long ID { get; set; } 
        public long ContactID { get; set; }
        public string Prefix { get; set; }
        public string Number { get; set; }
        public long PhoneTypeID { get; set; }
    }
}
