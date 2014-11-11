namespace Lekarite.Mvc.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    using Lekarite.Models;

    public class CityViewModel
    {
        public static Expression<Func<City, CityViewModel>> FromCity
        {
            get
            {
                return city => new CityViewModel
                {
                    Id = city.Id,
                    PostalCode = city.PostalCode,
                    Name = city.Name,
                    Doctors = city.Doctors
                };
            }
        }

        public int Id { get; set; }

        public int PostalCode { get; set; }

        public string Name { get; set; }

        public ICollection<Doctor> Doctors { get; set; }
    }
}