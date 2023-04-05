using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SchmersalGlobalTask.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SchmersalGlobalTask.Infrastructure
{
    public class RepositoryDBContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }

        public RepositoryDBContext(DbContextOptions options)
        : base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<Movie>().HasData(
            new Movie
            {
                Id = 1,
                Title = "Movie 1",
                Genre = "Drama",
                ReleaseYear = new DateTime(2020, 1, 1)
            },
            new Movie
            {
                Id = 2,
                Title = "Movie 2",
                Genre = "Funny",
                ReleaseYear = new DateTime(2020, 1, 1)
            },
            new Movie
            {
                Id = 3,
                Title = "Movie 3",
                Genre = "Drama",
                ReleaseYear = new DateTime(2020, 1, 1)
            },
              new Movie
              {
                  Id = 4,
                  Title = "Movie 4",
                  Genre = "Action",
                  ReleaseYear = new DateTime(2020, 1, 1)
              },
                new Movie
                {
                    Id = 5,
                    Title = "Movie 5",
                    Genre = "Adventure",
                    ReleaseYear = new DateTime(2020, 1, 1)
                },
                  new Movie
                  {
                      Id = 6,
                      Title = "Movie 6",
                      Genre = "Drama",
                      ReleaseYear = new DateTime(2020, 1, 1)
                  },
                   new Movie
                   {
                       Id = 7,
                       Title = "Movie 7",
                       Genre = "Action",
                       ReleaseYear = new DateTime(2020, 1, 1)
                   }
        ); 
            
        }
    }
}