using System;
using System.Collections.Generic;

namespace SelfProjectDataAccess.Models
{
    public partial class Actor
    {
        public Actor()
        {
            AwardsNavigation = new HashSet<Award>();
            News = new HashSet<News>();
            Awards = new HashSet<Award>();
            Movies = new HashSet<Movie>();
        }

        public int ActorId { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Biography { get; set; }
        public string Images { get; set; }

        public virtual ICollection<Award> AwardsNavigation { get; set; }
        public virtual ICollection<News> News { get; set; }

        public virtual ICollection<Award> Awards { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }
    }
}
