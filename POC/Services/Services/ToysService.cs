using POC_Data.Context;
using Microsoft.EntityFrameworkCore;
using POC_Models.Models;
using POC_Models.ViewModels;
using POC_Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POC_Services.Services
{
    public class ToysService : IToysService
    {
        private readonly ApplicationDbContext _context;
        public ToysService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateToy(Toys toy)
        {
            _context.Toys.Add(toy);
           await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteToy(int id)
        {
            var toy = await _context.Toys.FirstOrDefaultAsync(t => t.Id == id);

            if (toy != null)
            {
                _context.Toys.Remove(toy);
                await _context.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<IList<ToysViewModel>> GetToysAsync()
        {
            var toys = await _context.Toys.Select(t => new ToysViewModel
            {
                Id = t.Id,
                Name = t.Name,
                Age = t.AgeRestriction,
                Price = Math.Round(t.Price, 2),
                Company = t.Company
            }).ToListAsync();

            return toys;
        }

        public async Task<bool> UpdateToy(Toys toy)
        {
            var getToy = await _context.Toys.FirstOrDefaultAsync(t => t.Id == toy.Id);

            if (getToy != null)
            {
                getToy.Name = toy.Name;
                getToy.Description= toy.Description;
                getToy.AgeRestriction = toy.AgeRestriction;
                getToy.Price = toy.Price;
                getToy.Company = toy.Company;
                getToy.ProductImage = toy.ProductImage;

                _context.Toys.Attach(getToy);
                await _context.SaveChangesAsync();

                return true;
            }

            return false;
        }
    }
}
