using System;


namespace Entities
{
    public class Base
    {        
        public long ID { get; set; } // Long needed here because EF can't use uint 
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }

    }
}
