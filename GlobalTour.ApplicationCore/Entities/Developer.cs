using System.Collections.Generic;

namespace ApplicationCore.Entities
{
    public class Developer : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int YearsOfExperience { get; set; }
        public decimal EstimatedIncome { get; set; }
        public Address Address { get; set; }
        public ICollection<WorkHistory> WorkHistories { get; set; }
    }
}