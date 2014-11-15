namespace Lekarite.Mvc.Models.Cities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    using Lekarite.Models;
    using Lekarite.Mvc.Infrastructure.Mapping;

    public class CitiesViewModel : IMapFrom<City>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int PostalCode { get; set; }

        public int DoctorsCount { get; set; }
        
        public void CreateMappings(AutoMapper.IConfiguration configuration)
        {
            configuration.CreateMap<City, CitiesViewModel>()
                .ForMember(c => c.DoctorsCount,
                opt => opt.MapFrom(c => c.Doctors.Count));
        }
    }
}