using Domain.Interfaces;
using Infrastructure.Contexts;

namespace Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DeviceWebDbContext _context;
        private bool _disposed;

        public UnitOfWork(DeviceWebDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Func To Commit Database
        /// </summary>
        public async Task<int> Commit()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Func Dispose
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
                if (disposing)
                    _context.Dispose();
            _disposed = true;
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }
    }
}
