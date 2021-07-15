using ApplicationCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GlobalTour.Services
{
    public interface IDevelopersService
    {
        Task<Developer> GetDeveloperById(int Id);
        IReadOnlyList<Developer> GetDeveloperWithAddressById(int Id);
    }
}