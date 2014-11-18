namespace Lekarite.Mvc.Models.Search
{
    using Lekarite.Models;
    using Lekarite.Mvc.Infrastructure.Mapping;
    
    public class DoctorSearchViewModel : IMapFrom<Doctor>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName { get; set; }

        public string Uin { get; set; }

        public string CityName { get; set; }

        public void CreateMappings(AutoMapper.IConfiguration configuration)
        {
            configuration.CreateMap<Doctor, DoctorSearchViewModel>()
                .ForMember(d => d.FullName, opt => opt.MapFrom(d => d.FirstName + " " + d.LastName));

            configuration.CreateMap<Doctor, DoctorSearchViewModel>()
                .ForMember(d => d.CityName, opt => opt.MapFrom(d => d.City.Name));
        }
    }
}