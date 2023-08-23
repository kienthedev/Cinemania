using System;
using System.Collections.Generic;

namespace SelfProjectDataAccess.Models
{
    public partial class News
    {
        public News()
        {
            Directors = new HashSet<Director>();
        }

        public int NewsId { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public DateTime? DatePublished { get; set; }
        public string Content { get; set; }
        public int? MovieId { get; set; }
        public int? ActorId { get; set; }
        public int? DirectorId { get; set; }

        public virtual Actor Actor { get; set; }
        public virtual Director Director { get; set; }
        public virtual Movie Movie { get; set; }

        public virtual ICollection<Director> Directors { get; set; }
    }
}
