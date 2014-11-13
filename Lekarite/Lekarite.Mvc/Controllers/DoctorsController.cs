namespace Lekarite.Mvc.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Lekarite.Data.Interfaces;
    using Lekarite.Mvc.Models;
    using Lekarite.Mvc.Models.Doctors;

    public class DoctorsController : BaseController
    {
        private const int ItemsPerPage = 15;

        public DoctorsController(ILekariteData data)
            : base(data)
        {
        }

        public ActionResult All(int page = 1)
        {
            var pagesCount = (int)Math.Ceiling(this.Data.Doctors.All().Count() / (double)ItemsPerPage);

            var doctors = this.Data
                .Doctors
                .All()
                .OrderBy(d => d.City.Name)
                .ThenBy(d => d.LastName)
                .Project().To<DoctorViewModel>()
                .Skip(ItemsPerPage * (page - 1))
                .Take(ItemsPerPage)
                .ToList();

            var model = new DoctorsPageViewModel
                {
                    Doctors = doctors,
                    CurrentPage = page,
                    PagesCount = pagesCount
                };

            return View(model);
        }

        public ActionResult Get(int? id)
        {
            var existingDoctor = this.Data
                .Doctors
                .All()
                .Where(d => d.Id == id)
                .Project()
                .To<DoctorViewModel>()
                .FirstOrDefault();

            if (existingDoctor == null)
            {
                return this.HttpNotFound("No such doctor existing.");
            }

            return View(existingDoctor);
        }
    }
}