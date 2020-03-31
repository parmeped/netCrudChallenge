using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts.Dto.Requests
{
    public class PaginationDto
    {
        public ushort Page { get; set; }
        public ushort Limit { get; set; }

    }
}
