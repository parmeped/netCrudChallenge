using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Contracts.Dto.Requests
{
    public class UpdateContactDto
    {        

        [Required, MinLength(5, ErrorMessage = "Min Length 5"), MaxLength(80, ErrorMessage = "Max Length 80")]
        public string Name { get; set; }
        
        [Required, Range(1, int.MaxValue, ErrorMessage = "Must be positive number")]
        public long CompanyID { get; set; }
        
        [Url]
        public string ProfileImage { get; set; }

        [Required, EmailAddress, MinLength(5, ErrorMessage = "Min Length 5"), MaxLength(80, ErrorMessage = "Max Length 80")]
        public string Email { get; set; }
        
        [Required, Timestamp]
        public DateTime BirthDate { get; set; }
        
        [Required, MinLength(3, ErrorMessage = "Min Length 3"), MaxLength(80, ErrorMessage = "Max Length 80")]
        public string StreetName { get; set; }

        [Required, Range(1, 20000, ErrorMessage = "Range Between 1 and 20000")]
        public ushort StreetNumber { get; set; }

        [Required, Range(1, int.MaxValue, ErrorMessage = "Must be positive number")]
        public long CityID { get; set; }
        public virtual List<PhoneDto> Phones { get; set; }
    }
}
