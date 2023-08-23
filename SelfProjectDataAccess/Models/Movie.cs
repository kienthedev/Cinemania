using System;
using System.Collections.Generic;

namespace SelfProjectDataAccess.Models
{
    public partial class Movie
    {
        public Movie()
        {
            Awards = new HashSet<Award>();
            Comments = new HashSet<Comment>();
            News = new HashSet<News>();
            Rates = new HashSet<Rate>();
            UserInteractions = new HashSet<UserInteraction>();
            Actors = new HashSet<Actor>();
            AwardsNavigation = new HashSet<Award>();
            Directors = new HashSet<Director>();
            Genres = new HashSet<Genre>();
            Languages = new HashSet<Language>();
            Tags = new HashSet<Tag>();
            Writers = new HashSet<Writer>();
        }

        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Rated { get; set; }
        public DateTime? ReleasedDate { get; set; }
        public string Plot { get; set; }
        public string Country { get; set; }
        public string Poster { get; set; }
        public decimal? BoxOffice { get; set; }
        public string Website { get; set; }
        public string Production { get; set; }
        public string Trailer { get; set; }

        public virtual ICollection<Award> Awards { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<News> News { get; set; }
        public virtual ICollection<Rate> Rates { get; set; }
        public virtual ICollection<UserInteraction> UserInteractions { get; set; }

        public virtual ICollection<Actor> Actors { get; set; }
        public virtual ICollection<Award> AwardsNavigation { get; set; }
        public virtual ICollection<Director> Directors { get; set; }
        public virtual ICollection<Genre> Genres { get; set; }
        public virtual ICollection<Language> Languages { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
        public virtual ICollection<Writer> Writers { get; set; }
    }
}
