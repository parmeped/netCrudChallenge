using System;
using System.ComponentModel.DataAnnotations;

namespace Contracts.Dto.Requests
{
    public class PaginationDto
    {
        public PaginationDto()
        {
            Limit = 5;
            Page = 1;
        }

        [Range(1, 20000, ErrorMessage = "Range between 1 and 20000")]
        public int Page { get; set; }
        [Required, Range(1, 50, ErrorMessage = "Range between 1 and 50")]
        public int Limit { get; set; }
      
    }   
}
