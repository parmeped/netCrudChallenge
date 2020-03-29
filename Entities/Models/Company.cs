using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class Company : Base
    {
        public string Name { get; set; }
        public string StreetName { get; set; }
        public ushort StreetNumber { get; set; }
        public uint CityID { get; set; }
        public virtual City City { get; set; }        
    }
}
