using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts.Dto.Requests
{
    public class PhoneRequestDto
    {
        public string Prefix { get; set; }
        public string Number { get; set; }
        public PaginationDto Pagination { get; set; }
    }
}
