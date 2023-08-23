using Microsoft.EntityFrameworkCore;
using SelfProjectDataAccess.DTO;
using SelfProjectDataAccess.Models;

namespace SelfProjectDataAccess.Interfaces
{
    public interface IMovieRepository : IBaseRepository<Movie>
    {
        IEnumerable<Movie> GetAllWithGenres();
    }
}
