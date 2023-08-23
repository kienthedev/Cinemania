using System;
using System.Collections.Generic;

namespace SelfProjectDataAccess.Models
{
    public partial class Writer
    {
        public Writer()
        {
            Movies = new HashSet<Movie>();
        }

        public int WriterId { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Biography { get; set; }
        public string Images { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
