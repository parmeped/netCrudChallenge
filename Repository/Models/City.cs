using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Models
{
    public class City : Base
    {
        public string Name { get; set; }
        public uint StateID { get; set; }
        public virtual State State { get; set; }

        public virtual List<Company> Companies { get; set; }

        public virtual List<Contact> Contacts { get; set; }
    }
}
