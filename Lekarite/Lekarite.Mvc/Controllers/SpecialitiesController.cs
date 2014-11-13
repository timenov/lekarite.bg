namespace Lekarite.Mvc.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using Lekarite.Data.Interfaces;

    public class SpecialitiesController : BaseController
    {
        public SpecialitiesController(ILekariteData data)
            : base(data)
        { }

        public ActionResult All()
        {
            return View();
        }
    }
}