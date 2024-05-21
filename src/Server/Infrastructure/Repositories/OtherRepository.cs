using Domain.Contracts;
using Domain.DTO.Branch;
using Domain.DTO.Category;
using Domain.DTO.Color;
using Domain.DTO.Product;
using Domain.DTO.Serie;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class OtherRepository : IOtherRepository
    {
        protected readonly DeviceWebDbContext _context;
        public OtherRepository(DeviceWebDbContext context)
        {
            _context = context;
        }
        public async Task<bool> AddFeedback(Feedback feedback)
        {
            try
            {
                _context.Set<Feedback>().Add(feedback);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> AddNofication(Notification notification)
        {
            try
            {
                _context.Set<Notification>().Add(notification);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<ProductFilter> GetProductFiltersAsync()
        {
            var category = await _context.Set<Category>().ToListAsync();
            var branch = await _context.Set<Branch>().ToListAsync();
            var color = await _context.Set<Color>().ToListAsync();
            
            var branches = branch.Select(p => new BranchDTO
            {
                Id = p.Id,
                Name = p.Name,
                UrlSlug = p.UrlSlug,
                ImageUrl = p.ImageUrl,
                // Map other relevant properties
            })
           .DistinctBy(b => b.Id)
           .ToList();

            var categories = category.Select(p => new CategoryDTO
            {
                Id = p.Id,
                Name = p.Name,
                ImageUrl = p.ImageUrl,
                UrlSlug = p.UrlSlug,
                // Map other relevant properties
            })
           .DistinctBy(c => c.Id)
           .ToList();

            var colors = color.Select(c => new ColorDTO
              {
                  Id = c.Id,
                  Name = c.Name,
                  UrlSlug = c.UrlSlug
              })
              .DistinctBy(c => c.Id)
              .ToList();

            return new ProductFilter
            {
                Branches = branches,
                Categories = categories,
                Colors = colors,
            };
        }
    }
}
