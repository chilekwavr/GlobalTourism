using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Entities
{
    public abstract class BaseEntity 
    {
        /// <inheritdoc />
        public int Id { get; set; }
    }
}
