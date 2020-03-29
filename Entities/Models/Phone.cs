using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class Phone : Base
    {
        public string Prefix { get; set; }

        public string Number { get; set; }

        public uint PhoneTypeID { get; set; }

        public virtual PhoneType PhoneType { get; set; }

        public uint ContactID { get; set; }

        public virtual Contact Contact { get; set; }
    }
}
