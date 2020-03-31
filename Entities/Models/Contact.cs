using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class Contact : Base
    {
        public string Name { get; set; }
        public long CompanyID { get; set; }
        public virtual Company Company { get; set; }
        public string ProfileImage { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }        
        public string StreetName { get; set; }
        public ushort StreetNumber { get; set; }
        public long CityID { get; set; }
        public virtual City City { get; set; }
        public virtual List<Phone> Phones { get; set; }
    }
}
