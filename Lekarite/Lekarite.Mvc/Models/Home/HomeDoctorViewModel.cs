namespace Lekarite.Mvc.Models.Home
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    using Lekarite.Models;
    using Lekarite.Mvc.Infrastructure.Mapping;

    public class HomeDoctorViewModel : IMapFrom<Doctor>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public City City { get; set; }

        public Speciality Speciality { get; set; }

        public float Rating { get; set; }

        public int RatingsCount { get; set; }

        public int CommentsCount { get; set; }

        public void CreateMappings(AutoMapper.IConfiguration configuration)
        {
            configuration.CreateMap<Doctor, HomeDoctorViewModel>()
                .ForMember(d => d.FullName,
                opt => opt.MapFrom(x => x.FirstName + " " + x.LastName));

            configuration.CreateMap<Doctor, HomeDoctorViewModel>()
                   .ForMember(d => d.Rating,
                   opt => opt.MapFrom(x => x.Rating.Count > 0
                       ? (float)x.Rating.Sum(r => r.Value) / x.Rating.Count : 0));

            configuration.CreateMap<Doctor, HomeDoctorViewModel>()
                .ForMember(d => d.RatingsCount,
                opt => opt.MapFrom(d => d.Rating.Count));

            configuration.CreateMap<Doctor, HomeDoctorViewModel>()
                .ForMember(d => d.CommentsCount,
                opt => opt.MapFrom(d => d.Comments.Count));
        }
    }
}