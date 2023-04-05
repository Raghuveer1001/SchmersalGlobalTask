using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Identity.Client;
using SchmersalGlobalTask.Domain.Entities;
using SchmersalGlobalTask.Domain.Repositories;
using System.Threading;

namespace SchmersalGlobalTask.Infrastructure.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly RepositoryDBContext _dbContext;
        public MovieRepository(RepositoryDBContext _dbContext)
        {
            this._dbContext = _dbContext;
        }

        public bool Add(Movie movie)
        {
            EntityEntry<Movie> entityEntry = _dbContext.Movies.Add(movie);
            if (entityEntry.State == EntityState.Added)
                return true;
            return false;
        }

        public bool Delete(long id)
        {
            var matched = _dbContext.Movies.Where(x => x.Id == id).FirstOrDefault();
            if (matched == null)
            {
                return false;
            }
            EntityEntry<Movie> entityEntry = _dbContext.Movies.Remove(matched);
            if (entityEntry.State == EntityState.Deleted)
                return true;
            return false;
        }

        public async Task<Movie> GetAsyncById(long id, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Movies.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }
        public async Task<IEnumerable<Movie>> GetAsyncByGenre(string genre, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Movies.Where(x=>x.Genre==genre) .ToListAsync(cancellationToken);
        }
        public async Task<IEnumerable<Movie>> GetAllAsync()
        {
            return await _dbContext.Movies.ToListAsync();
        }

        public bool Update(Movie entity)
        {
            _dbContext.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            return true;
        }
     
    }
}
