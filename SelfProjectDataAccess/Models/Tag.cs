using System;
using System.Collections.Generic;

namespace SelfProjectDataAccess.Models
{
    public partial class Tag
    {
        public Tag()
        {
            Movies = new HashSet<Movie>();
        }

        public int TagId { get; set; }
        public string TagName { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
