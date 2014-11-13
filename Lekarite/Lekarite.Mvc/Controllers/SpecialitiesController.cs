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
    using Lekarite.Mvc.Models.Specialities;

    public class SpecialitiesController : BaseController
    {
        private const int ItemPerPage = 15;

        public SpecialitiesController(ILekariteData data)
            : base(data)
        { }

        public ActionResult All(int page = 1)
        {
            var pagesCount = (int)Math.Ceiling(this.Data.Specialities.All().Count() / (decimal)ItemPerPage);
            var specialities = this.Data
                .Specialities
                .All()
                .Project().To<SpecialityViewModel>()
                .ToList();

            var model = new PagedList<SpecialityViewModel>(specialities, page, ItemPerPage);

            return View(model);
        }

        public ActionResult Get(int? id)
        {
            var existingSpeciality = this.Data
                .Specialities
                .All()
                .Where(s => s.Id == id)
                .Project().To<SpecialityViewModel>()
                .FirstOrDefault();

            if (existingSpeciality == null)
            {
                return this.HttpNotFound("There is no such record.");                     
            }

            return View(existingSpeciality);
        }
    }
}