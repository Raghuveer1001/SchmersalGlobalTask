using SchmersalGlobalTask.Contracts;

namespace SchmersalGlobalTask.Services.Abstraction
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieDTO>> GetMovieAllAsync(CancellationToken cancellationToken = default);
        Task<MovieDTO> GetMovieByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<MovieDTO>> GetMovieByGenreAsync(string genre, CancellationToken cancellationToken = default);
        Task<int> CreateMovieAsync(MovieDTO createDTO, CancellationToken cancellationToken = default);
        Task<bool> UpdateMovieAsync(MovieDTO updateDTO, CancellationToken cancellationToken = default);
        Task<bool> DeleteMovieAsync(int id, CancellationToken cancellationToken = default);
    }
}