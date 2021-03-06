﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class City : Base
    {
        public string Name { get; set; }
        public long StateID { get; set; }
        public virtual State State { get; set; }

        public virtual List<Company> Companies { get; set; }

        public virtual List<Contact> Contacts { get; set; }
    }
}
