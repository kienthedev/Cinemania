using System;
using System.Collections.Generic;

namespace SelfProjectDataAccess.Models
{
    public partial class Language
    {
        public Language()
        {
            Movies = new HashSet<Movie>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string IsoCode { get; set; }
        public string Region { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
