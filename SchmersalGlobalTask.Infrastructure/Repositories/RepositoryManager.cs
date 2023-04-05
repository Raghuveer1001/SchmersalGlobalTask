using SchmersalGlobalTask.Domain.Repositories;

namespace SchmersalGlobalTask.Infrastructure.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly Lazy<IUnitOfWork> _lazyUnitOfWork;
        private readonly Lazy<IMovieRepository> _lazyMovieRepository;

        public RepositoryManager(RepositoryDBContext dbContext)
        {
        
            _lazyMovieRepository = new Lazy<IMovieRepository>(() => new MovieRepository(dbContext));
            _lazyUnitOfWork = new Lazy<IUnitOfWork>(() => new UnitOfWork(dbContext));
        }

        public IUnitOfWork UnitOfWork => _lazyUnitOfWork.Value;
        public IMovieRepository MovieRepository => _lazyMovieRepository.Value;
    }
}