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

    public class DoctorsController : BaseController
    {
        public DoctorsController(ILekariteData data)
            : base(data)
        {
        }

        // GET: Doctors
        public ActionResult Index()
        {
            var firstTenDoctors =
                this.Data
                .Doctors
                .All()
                .Take(10)
                .Project()
                .To<DoctorViewModel>();

            return View("FirstTen", firstTenDoctors);
        }
    }
}