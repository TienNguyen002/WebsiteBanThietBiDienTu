using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Contexts;

namespace Infrastructure.Repositories
{
    public class StatusRepository : GenericRepository<Status>, IStatusRepository
    {
        public StatusRepository(DeviceWebDbContext dbContext) : base(dbContext) { }
    }
}
