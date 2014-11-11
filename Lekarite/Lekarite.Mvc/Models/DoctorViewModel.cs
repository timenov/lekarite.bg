namespace Lekarite.Mvc.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    using Lekarite.Models;
    using Lekarite.Mvc.Infrastructure.Mapping;

    public class DoctorViewModel : IMapFrom<Doctor>
    {
        public string Uin { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string LastName { get; set; }

        public string PracticeAt { get; set; }

        // Did doctor working with National health insurance fund
        public bool WorkingWithNhif { get; set; }

        public string Phone { get; set; }

        public string Gsm { get; set; }

        public string Email { get; set; }

        public string SocialNetworks { get; set; }

        public string Address { get; set; }

        public virtual User User { get; set; }

        public virtual City City { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Rating> Rating { get; set; }

        public virtual ICollection<Speciality> Specialties { get; set; }
    }
}