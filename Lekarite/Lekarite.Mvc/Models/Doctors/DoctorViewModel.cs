namespace Lekarite.Mvc.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    using Lekarite.Models;
    using Lekarite.Mvc.Infrastructure.Mapping;

    public class DoctorViewModel : IMapFrom<Doctor>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Uin { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string LastName { get; set; }

        public string FullName { get; set; }

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

        public float Rating { get; set; }

        public int RatingsCount { get; set; }

        public Speciality Specialty { get; set; }

        public void CreateMappings(AutoMapper.IConfiguration configuration)
        {
            configuration.CreateMap<Doctor, DoctorViewModel>()
                .ForMember(d => d.Rating, 
                opt => opt.MapFrom(x => x.Rating.Count > 0
                    ? (float)x.Rating.Sum(r => r.Value) / x.Rating.Count : 0));

            configuration.CreateMap<Doctor, DoctorViewModel>()
                .ForMember(d => d.FullName,
                opt => opt.MapFrom(x => x.FirstName + " " + x.LastName));

            configuration.CreateMap<Doctor, DoctorViewModel>()
                .ForMember(d => d.RatingsCount,
                opt => opt.MapFrom(d => d.Rating.Count));
        }
    }
}