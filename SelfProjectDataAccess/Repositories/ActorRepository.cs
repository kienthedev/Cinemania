using SelfProjectDataAccess.Interfaces;
using SelfProjectDataAccess.Models;

namespace SelfProjectDataAccess.Repositories
{
    public class ActorRepository : BaseRepository<Actor>, IActorRepository
    {
        public ActorRepository(SelfProjectContext context) : base(context)
        {
        }
    }
}
