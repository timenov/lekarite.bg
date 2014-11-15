namespace Lekarite.Mvc.Models.Specialities
{
    using System.Collections.Generic;
    using System.Web;

    using Lekarite.Models;
    using Lekarite.Mvc.Models.Doctors;
    using Lekarite.Mvc.Infrastructure.Mapping;

    public class SpecialityViewModel : IMapFrom<Speciality>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<SpecialityDoctorViewModel> Doctors { get; set; }
    }
}