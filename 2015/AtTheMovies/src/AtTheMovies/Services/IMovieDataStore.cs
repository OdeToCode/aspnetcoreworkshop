using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtTheMovies.Data;
using AtTheMovies.Models;

namespace AtTheMovies.Services
{
    public interface IMovieDataStore
    {
        IEnumerable<Movie> GetAll();
        Movie GetById(int id);
    }

    public class SqlMovieStore : IMovieDataStore
    {
        private readonly MovieDbContext _context;

        public SqlMovieStore(MovieDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Movie> GetAll()
        {
            return _context.Movies.OrderByDescending(m => m.ReleaseOn.Year);
        }

        public Movie GetById(int id)
        {
            return _context.Movies.FirstOrDefault(m => m.Id == id);
        }
    }

    public class InMemoryMovieStore : IMovieDataStore
    {
        public InMemoryMovieStore()
        {
            movies = new List<Movie>()
            {
                new Movie { Id = 1, Title="Star Wars", Length=90, ReleaseOn = new DateTime(1979, 6, 1) },
                new Movie { Id = 2, Title="The Hobbit", Length=400, ReleaseOn = new DateTime(2015, 10, 15) },
                new Movie { Id = 3, Title="Back to the Future", Length=120, ReleaseOn = new DateTime(1987, 3, 30) }
            };

        }

        public IEnumerable<Movie> GetAll()
        {
            return movies;
        }

        public Movie GetById(int id)
        {
            return movies.FirstOrDefault(m => m.Id == id);
        }

        private static List<Movie> movies;
    }
}
