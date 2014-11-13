namespace Lekarite.Mvc.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;
    using PagedList;

    using Lekarite.Data.Interfaces;
    using Lekarite.Mvc.Models;

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
                .ToList();

            var model = new PagedList<DoctorViewModel>(doctors, page, ItemsPerPage);

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