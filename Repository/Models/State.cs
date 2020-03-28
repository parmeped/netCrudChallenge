using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Models
{
    public class State : Base
    {
        public string Name { get; set; }
        public virtual List<City> Cities { get; set; }
    }
}
