using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Models
{
    public class PhoneType : Base
    {
        public string Name { get; set; } 
        public virtual List<Phone> Phones { get; set; }
    }
}
