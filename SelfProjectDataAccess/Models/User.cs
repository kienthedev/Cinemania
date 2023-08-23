using System;
using System.Collections.Generic;

namespace SelfProjectDataAccess.Models
{
    public partial class User
    {
        public User()
        {
            Comments = new HashSet<Comment>();
            Rates = new HashSet<Rate>();
            UserInteractions = new HashSet<UserInteraction>();
        }

        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string ProfileImage { get; set; }
        public bool? Gender { get; set; }
        public bool? Type { get; set; }
        public string Country { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Rate> Rates { get; set; }
        public virtual ICollection<UserInteraction> UserInteractions { get; set; }
    }
}
