using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contracts.Dto.Responses
{
    public class PhoneDto
    {
        public uint ID { get; set; }
        public string Prefix { get; set; }
        public string Number { get; set; }
        public uint TypeID { get; set; }
        public uint ContactID { get; set; }
    }
}
