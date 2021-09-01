using POC_Models.Models;
using POC_Models.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace POC_Services.Contracts
{
    public interface IToysService
    {
        Task<IEnumerable<ToysViewModel>> GetToysAsync();
        Task CreateToyAsync(Toys toy);
        Task<bool> UpdateToyAsync(Toys toy);
        Task<bool> DeleteToyAsync(int id);
    }
}
