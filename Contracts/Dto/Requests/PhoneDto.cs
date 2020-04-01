using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Contracts.Dto.Requests
{
    public class PhoneDto
    {

        public long ID { get; set; } 

        public long ContactID { get; set; }

        [Required, Range(11, 999, ErrorMessage = "Range between 11 and 999")]
        public ushort Prefix { get; set; }

        [Required, Range(11111111, 99999999, ErrorMessage = "Range between 11111111 and 99999999")]
        public uint Number { get; set; }

        [Range(1,2, ErrorMessage = "Range between 1 and 2")] // We only have 2 types
        public long PhoneTypeID { get; set; }
    }
}
