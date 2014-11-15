namespace Lekarite.Mvc.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using PagedList;
    using AutoMapper.QueryableExtensions;

    using Lekarite.Data.Interfaces;
    using Lekarite.Mvc.Models.Cities;

    public class CitiesController : BaseController
    {
        private const int CitiesPerPage = 15;

        public CitiesController(ILekariteData data)
            :base(data)
        { }

        public ActionResult All(int page = 1)
        {
            var cities = this.Data
                .Cities
                .All()
                .Project().To<CitiesViewModel>()
                .ToList();

            if (cities == null)
            {
                return this.HttpNotFound();
            }

            var model = new PagedList<CitiesViewModel>(cities, page, CitiesPerPage);

            return this.View(model);
        }
    }
}