using SchmersalGlobalTask.Domain.Repositories;
using SchmersalGlobalTask.Services.Abstraction;

namespace SchmersalGlobalTask.Services
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IMovieService> _lazyMovieService;

        public ServiceManager(IRepositoryManager repositoryManager)
        {
            _lazyMovieService = new Lazy<IMovieService>(() => new MovieService(repositoryManager));
        }

        public IMovieService MovieSrvc => _lazyMovieService.Value;
    }
}