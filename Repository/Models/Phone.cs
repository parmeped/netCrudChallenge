using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Models
{
    public class Phone : Base
    {
        public string Prefix { get; set; }

        public string Number { get; set; }

        public ushort PhoneTypeID { get; set; }

        public virtual PhoneType PhoneType { get; set; }

        public uint ContactID { get; set; }

        public virtual Contact Contact { get; set; }
    }
}
