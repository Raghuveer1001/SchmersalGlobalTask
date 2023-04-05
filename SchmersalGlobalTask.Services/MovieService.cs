using Mapster;
using SchmersalGlobalTask.Contracts;
using SchmersalGlobalTask.Domain.Repositories;
using SchmersalGlobalTask.Services.Abstraction;
using SchmersalGlobalTask.Domain.Entities;
using SchmersalGlobalTask.Domain.Exceptions;

namespace SchmersalGlobalTask.Services
{
    public sealed class MovieService : IMovieService
    {
        private readonly IRepositoryManager _repositoryManager;
        public MovieService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<int> CreateMovieAsync(MovieDTO createDTO, CancellationToken cancellationToken = default)
        {
            var movie = createDTO.Adapt<Movie>();
            if (_repositoryManager.MovieRepository.Add(movie))
            {
                await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
            }
            return movie.Id;
        }

        public async Task<bool> DeleteMovieAsync(int id, CancellationToken cancellationToken = default)
        {
            var match = _repositoryManager.MovieRepository.GetAsyncById(id, cancellationToken);
            if (match != null)
            {
                if (_repositoryManager.MovieRepository.Delete(id))
                {
                    var result = await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
                    if (result == 0)
                        return false;
                    return true;
                }
            }
            {
                return false;
            }
        }

        public async Task<IEnumerable<MovieDTO>> GetMovieAllAsync(CancellationToken cancellationToken = default)
        {
            var match = await _repositoryManager.MovieRepository.GetAllAsync();
            IEnumerable<MovieDTO> moviesDTO = match.Adapt<IEnumerable<MovieDTO>>();
            return moviesDTO;
        }

        public async Task<MovieDTO> GetMovieByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var match = await _repositoryManager.MovieRepository.GetAsyncById(id, cancellationToken);
            if (match == null)
                throw new MovieNotFoundException("Id", Convert.ToString(id));
            var dto = match.Adapt<MovieDTO>();
            return dto;
        }

        public async Task<IEnumerable<MovieDTO>> GetMovieByGenreAsync(string genre, CancellationToken cancellationToken = default)
        {
            var match = await _repositoryManager.MovieRepository.GetAsyncByGenre(genre, cancellationToken);
            if (match == null || !match.Any())
                throw new MovieNotFoundException("Genre", genre);
            var dtos = match.Adapt<IEnumerable<MovieDTO>>();
            return dtos;
        }

        public async Task<bool> UpdateMovieAsync(MovieDTO updateDTO, CancellationToken cancellationToken = default)
        {
            var match = await _repositoryManager.MovieRepository.GetAsyncById(updateDTO.Id, cancellationToken);
            if (match == null)
                throw new MovieNotFoundException("Id", Convert.ToString(updateDTO.Id));
            match.Title = updateDTO.Title;
            match.Genre = updateDTO.Genre;
            var result = await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
            if (result > 0)
                return true;
            return false;
        }
    }
}
