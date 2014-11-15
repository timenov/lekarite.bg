namespace Lekarite.Mvc.Models.Specialities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    using Lekarite.Models;
    using Lekarite.Mvc.Infrastructure.Mapping;

    public class SpecialityDoctorViewModel : IMapFrom<Doctor>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string CityName { get; set; }

        public float Rating { get; set; }

        public int CommentsCount { get; set; }

        public void CreateMappings(AutoMapper.IConfiguration configuration)
        {
            configuration.CreateMap<Doctor, SpecialityDoctorViewModel>()
                .ForMember(d => d.FullName,
                opt => opt.MapFrom(x => x.FirstName + " " + x.LastName));

            configuration.CreateMap<Doctor, SpecialityDoctorViewModel>()
                .ForMember(d => d.CityName,
                opt => opt.MapFrom(x => x.City.Name));

            configuration.CreateMap<Doctor, SpecialityDoctorViewModel>()
                   .ForMember(d => d.Rating,
                   opt => opt.MapFrom(x => x.Rating.Count > 0
                       ? (float)x.Rating.Sum(r => r.Value) / x.Rating.Count : 0));

            configuration.CreateMap<Doctor, SpecialityDoctorViewModel>()
                   .ForMember(d => d.CommentsCount,
                   opt => opt.MapFrom(x => x.Comments.Count));
        }
    }
}