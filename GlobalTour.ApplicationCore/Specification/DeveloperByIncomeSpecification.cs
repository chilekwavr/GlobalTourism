using ApplicationCore.Entities;

namespace ApplicationCore.Specification
{
    public class DeveloperByIncomeSpecification : BaseSpecifcation<Developer>
    {
        public DeveloperByIncomeSpecification()
        {
            AddOrderByDescending(x => x.EstimatedIncome);
        }
    }
}