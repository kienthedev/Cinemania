using SelfProjectDataAccess.Interfaces;
using SelfProjectDataAccess.Models;

namespace SelfProjectDataAccess.Repositories
{
    public class AwardRepository : BaseRepository<Award>, IAwardRepository
    {
        public AwardRepository(SelfProjectContext context) : base(context)
        {
        }
    }
}
