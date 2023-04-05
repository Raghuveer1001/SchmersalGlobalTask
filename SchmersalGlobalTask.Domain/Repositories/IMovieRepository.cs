using SchmersalGlobalTask.Domain.Entities;

namespace SchmersalGlobalTask.Domain.Repositories
{
    public interface IMovieRepository
    {
        Task<Movie> GetAsyncById(long id, CancellationToken cancellationToken);
        Task<IEnumerable<Movie>> GetAsyncByGenre(string genre, CancellationToken cancellationToken);
        Task<IEnumerable<Movie>> GetAllAsync();
        bool Add(Movie movie);
        bool Delete(long id);
        bool Update(Movie entity);
    }
}
