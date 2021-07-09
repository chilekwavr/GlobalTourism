using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class ContactDetail:BaseEntity
    {
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
