using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lekarite.Mvc.Controllers
{
    public class CitiesController : Controller
    {
        public ActionResult All()
        {
            return View();
        }
    }
}