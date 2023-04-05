using SchmersalGlobalTask.Domain.Repositories;

namespace SchmersalGlobalTask.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RepositoryDBContext _dbContext;

        public UnitOfWork(RepositoryDBContext context)
        {
            _dbContext = context;
        }
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return  _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
