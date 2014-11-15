namespace Lekarite.Mvc.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Web;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;
    using PagedList;

    using Lekarite.Data.Interfaces;
    using Lekarite.Models;
    using Lekarite.Mvc.Models;
    using Lekarite.Mvc.Models.Comments;
    using Lekarite.Mvc.Models.Doctors;
    using Lekarite.Mvc.Models.Specialities;

    public class DoctorsController : BaseController
    {
        private const int ItemsPerPage = 15;

        public DoctorsController(ILekariteData data)
            : base(data)
        { }

        public ActionResult All(int page = 1, int? city = null, int? speciality = null)
        {
            ViewBag.CityId = city;
            ViewBag.SpecialityId = speciality;

            var doctors = this.Data
                .Doctors
                .All()
                .Where(d => (d.CityId == city | city == null) && (d.SpecialityId == speciality | speciality == null))
                .OrderBy(d => d.City.Name)
                .ThenBy(d => d.LastName)
                .Project().To<DoctorViewModel>()
                .ToList();

            var citiesList = this.Data
                .Cities
                .All()
                .Select(c => new SelectListItem { Text = c.Name, Value = c.Id.ToString() })
                .ToList();
            var selectedAll = new SelectListItem { Text = "Всички", Value = "" };
            citiesList.Insert(0, selectedAll);

            var specialitiesList = this.Data
                .Specialities
                .All()
                .Select(s => new SelectListItem { Text = s.Name, Value = s.Id.ToString() })
                .ToList();
            specialitiesList.Insert(0, selectedAll);

            var model = new FilterDoctorsViewModel()
            {
                Doctors = new PagedList<DoctorViewModel>(doctors, page, ItemsPerPage),
                Cities = citiesList,
                Specialities = specialitiesList
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