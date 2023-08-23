using SelfProjectDataAccess.Interfaces;
using SelfProjectDataAccess.Models;

namespace SelfProjectDataAccess.Repositories
{
    public class GenreRepository : BaseRepository<Genre>, IGenreRepository
    {
        public GenreRepository(SelfProjectContext context) : base(context)
        {
        }
    }
}
