using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Specification;
using GlobalTour.Services.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GlobalTour.Services
{
    public class DevelopersService : IDevelopersService
    {
        private readonly IGenericRepository<Developer> _developerService;

        public DevelopersService(IGenericRepository<Developer> developerService)
        {
            _developerService = developerService;
        }

        public async Task<Developer> GetDeveloperById(int Id)
        {
            return await _developerService.GetByIdAsync(Id);
        }

        public IReadOnlyList<Developer> GetDeveloperWithAddressById(int Id)
        {
            var specification = new DeveloperWithAddressSpecification(Id);
            var developer = _developerService.FindWithSpecificationPattern(specification);
            return developer.ToReadOnly();
        }
    }

}
