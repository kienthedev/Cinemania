using System;
using System.Collections.Generic;

namespace SelfProjectDataAccess.Models
{
    public partial class UserInteraction
    {
        public int UserId { get; set; }
        public int MovieId { get; set; }
        public DateTime? Timestamp { get; set; }

        public virtual Movie Movie { get; set; }
        public virtual User User { get; set; }
    }
}
