using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Contracts.Dto.Requests
{
    public class PhoneRequestDto
    {
        [Required, Range(11, 999, ErrorMessage = "Range between 11 and 999")]
        public ushort Prefix { get; set; }

        [Required, Range(1111, 99999999, ErrorMessage = "Range between 1111 and 99999999")]
        public uint Number { get; set; }        
        public PaginationDto Pagination { get; set; }
    }
}
