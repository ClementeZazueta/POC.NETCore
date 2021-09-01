using Models.Models;
using POC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IToysService
    {
        Task<IList<ToysViewModel>> GetToysAsync();
        Task CreateToy(Toys toy);
        Task<bool> UpdateToy(Toys toy);
        Task<bool> DeleteToy(int id);
    }
}
