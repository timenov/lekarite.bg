namespace Lekarite.Mvc.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Web;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Lekarite.Data;
    using Lekarite.Data.Interfaces;
    using Lekarite.Models;
    using Lekarite.Mvc.Models;
    using Lekarite.Mvc.Models.Search;

    public class SearchController : BaseController
    {
        private ILekariteData data;

        public SearchController(ILekariteData data)
            : base(data)
        { }

        public ActionResult Results(string search)
        {
            ViewData["searchString"] = search;
            search = search.Trim();
            if (search.IndexOf(' ') != -1)
            {
                search = search.Replace(" ", "|");
            }

            Regex regex = new Regex(search, RegexOptions.IgnoreCase);

            var results = this.Data
                .Doctors
                .All()
                .Project().To<DoctorSearchViewModel>()
                .AsEnumerable()
                .Where(d => regex.IsMatch(d.FirstName.ToString()) | regex.IsMatch(d.LastName.ToString()));

            if (this.Request.IsAjaxRequest())
            {
                if (search.Length > 2)
                {
                    var model = results.OrderBy(d => d.LastName).Take(5).ToList();
                    return this.PartialView("_AjaxResults", model);
                }
                else
                {
                    return this.Content("<span class=\"list-group-item\">Недостатъчна дължина</span>");
                }
                
            }

            return this.View(results);
        }
    }
}