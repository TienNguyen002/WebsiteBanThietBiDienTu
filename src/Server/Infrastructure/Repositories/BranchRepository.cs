﻿using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class BranchRepository : GenericRepository<Branch>, IBranchRepository
    {
        public BranchRepository(DeviceWebDbContext context) : base(context) { }

        /// <summary>
        /// Delete Branch By Id
        /// </summary>
        /// <param name="id"> Id Of Branch want to delete </param>
        /// <returns> Deleted Branch </returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> DeleteBranch(int id)
        {
            var branchToDelete = await _context.Set<Branch>()
                .Include(b => b.Products)
                .Where(b => b.Id == id)
                .FirstOrDefaultAsync();
            try
            {
                _context.Remove(branchToDelete);
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Get Branch By Slug
        /// </summary>
        /// <param name="slug"> UrlSlug want to get Branch </param>
        /// <returns> Branch With UrlSlug want to get </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<Branch> GetBranchBySlug(string slug)
        {
            return await _context.Set<Branch>()
                .Include(b => b.Products)
                .Where(b => b.UrlSlug == slug)
                .FirstOrDefaultAsync();
        }
    }
}
