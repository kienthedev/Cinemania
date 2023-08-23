using System;
using System.Collections.Generic;

namespace SelfProjectDataAccess.Models
{
    public partial class Rate
    {
        public int RateId { get; set; }
        public decimal? NumericRating { get; set; }
        public DateTime? Time { get; set; }
        public int MovieId { get; set; }
        public int UserId { get; set; }

        public virtual Movie Movie { get; set; }
        public virtual User User { get; set; }
    }
}
