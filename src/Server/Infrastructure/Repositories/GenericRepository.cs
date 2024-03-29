using Domain.Interfaces.Repositories;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly DeviceWebDbContext _context;

        public GenericRepository(DeviceWebDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Add Entity To DB
        /// </summary>
        /// <param name="entity"> Entity in DB </param>
        /// <returns> Added Entity </returns>
        /// <exception cref="Exception"></exception>
        public async Task Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        /// <summary>
        /// Get All Data Entity In DB
        /// </summary>
        /// <returns> A List Of Data Entity </returns>
        public async Task<IList<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        /// <summary>
        /// Get Data Entity By Id
        /// </summary>
        /// <param name="id"> Id of entity want to get </param>
        /// <returns> Entity Has Id want to get </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<T> GetById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
    }
}
