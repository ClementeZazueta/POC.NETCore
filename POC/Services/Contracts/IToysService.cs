using POC_Models.Models;
using POC_Models.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace POC_Services.Contracts
{
    public interface IToysService
    {
        Task<IList<ToysViewModel>> GetToysAsync();
        Task CreateToy(Toys toy);
        Task<bool> UpdateToy(Toys toy);
        Task<bool> DeleteToy(int id);
    }
}
