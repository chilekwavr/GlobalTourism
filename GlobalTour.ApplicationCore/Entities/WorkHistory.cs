using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class WorkHistory : BaseEntity
    {
        public string Name { get; set; }

        public Developer Developer { get; set; }
    }
}
