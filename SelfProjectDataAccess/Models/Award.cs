using System;
using System.Collections.Generic;

namespace SelfProjectDataAccess.Models
{
    public partial class Award
    {
        public Award()
        {
            Actors = new HashSet<Actor>();
            Directors = new HashSet<Director>();
            Movies = new HashSet<Movie>();
        }

        public int AwardId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public DateTime? Year { get; set; }
        public int? MovieId { get; set; }
        public int? ActorId { get; set; }
        public int? DirectorId { get; set; }

        public virtual Actor Actor { get; set; }
        public virtual Director Director { get; set; }
        public virtual Movie Movie { get; set; }

        public virtual ICollection<Actor> Actors { get; set; }
        public virtual ICollection<Director> Directors { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }
    }
}
