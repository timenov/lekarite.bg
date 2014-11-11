namespace Lekarite.Mvc.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using Lekarite.Data;
    using Lekarite.Data.Interfaces;
    using Lekarite.Models;
    using Lekarite.Mvc.Models;

    public class HomeController : BaseController
    {
        public HomeController(ILekariteData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About(int? id)
        {
            if (id == null)
            {
                return this.Redirect("~/Home/About/25");
            }
            ViewBag.Message = "Your application description page.";

            var existingCity = this.Data.Cities
                .All()
                .Where(c => c.Id == id)
                .Select(CityViewModel.FromCity)
                .FirstOrDefault();
            if (existingCity == null)
            {
                return this.HttpNotFound();
            }

            return View(existingCity);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}