using Microsoft.EntityFrameworkCore;
using SelfProjectDataAccess.Interfaces;
using SelfProjectDataAccess.Models;

namespace SelfProjectDataAccess.Repositories
{
    public class MovieRepository : BaseRepository<Movie>, IMovieRepository
    {
        protected readonly DbSet<Movie> _dbSet;
        protected readonly SelfProjectContext _context;
        public MovieRepository(SelfProjectContext context) : base(context)
        {
            this._context = context;
            this._dbSet = context.Set<Movie>();
        }
        public virtual IEnumerable<Movie> GetAllWithGenres()
        {
            var moviesWithGenres = _dbSet.Include(x => x.Genres).Select(movie => new Movie
            {
                MovieId = movie.MovieId,
                Title = movie.Title,
                Rated = movie.Rated,
                ReleasedDate = movie.ReleasedDate,
                Plot = movie.Plot,
                Country = movie.Country,
                Poster = movie.Poster,
                BoxOffice = movie.BoxOffice,
                Website = movie.Website,
                Production = movie.Production,
                Trailer = movie.Trailer,
                Genres = movie.Genres.Select(genre => new Genre
                {
                    GenreId = genre.GenreId,
                    GenreName = genre.GenreName,
                    Description = genre.Description
                }).ToList()
            })
            .ToList();
            return moviesWithGenres;
        }
    }
}
