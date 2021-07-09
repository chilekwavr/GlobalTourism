using ApplicationCore.Entities;

namespace ApplicationCore.Specification
{
    public class DeveloperWithAddressSpecification : BaseSpecifcation<Developer>
    {
        public DeveloperWithAddressSpecification(int Id) : base(x=>x.Id == Id)//(x => x.EstimatedIncome > years)
        {
            AddInclude(x => x.WorkHistories);
        }
    }
}