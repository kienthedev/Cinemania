using System;
using System.Collections.Generic;

namespace SelfProjectDataAccess.Models
{
    public partial class Comment
    {
        public int CommentId { get; set; }
        public string Content { get; set; }
        public int? ReplyTo { get; set; }
        public DateTime? Time { get; set; }
        public int? MovieId { get; set; }
        public int? UserId { get; set; }

        public virtual Movie Movie { get; set; }
        public virtual User User { get; set; }
    }
}
