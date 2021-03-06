﻿namespace Lekarite.Mvc.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Lekarite.Data;
    using Lekarite.Data.Interfaces;
    using Lekarite.Models;
    using Lekarite.Mvc.Models;
    using Lekarite.Mvc.Models.Home;

    public class HomeController : BaseController
    {
        public HomeController(ILekariteData data)
            : base(data)
        {
        }

        //[OutputCache(Duration = 5 * 60)]
        public ActionResult Index()
        {
            var homeTables = new HomeTablesViewModel();

            var mostCommented =
                this.Data
                .Doctors
                .All()
                .OrderByDescending(d => d.Comments.Count)
                .Take(5)
                .Project()
                .To<HomeDoctorViewModel>();
            homeTables.MostCommented = mostCommented;

            var highestRating =
                this.Data
                .Doctors
                .All()
                .Where(d => d.Rating.Count > 4)
                .OrderByDescending(d => (float)d.Rating.Sum(r => r.Value) / d.Rating.Count)
                .Take(5)
                .Project()
                .To<HomeDoctorViewModel>();
            homeTables.HighestRating = highestRating;

            return View(homeTables);
        }
    }
}