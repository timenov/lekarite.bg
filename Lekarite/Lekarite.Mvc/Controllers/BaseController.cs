namespace Lekarite.Mvc.Controllers
{
    using System;
    using System.Web.Routing;
    using System.Web.Mvc;
    using System.Linq;

    using Lekarite.Data.Interfaces;
    using Lekarite.Models;

    public class BaseController : Controller
    {
        public BaseController(ILekariteData data)
        {
            this.Data = data;
        }

        protected ILekariteData Data { get; set; }

        protected User User { get; private set; }

        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        {
            this.User = this.Data.Users.All().Where(u => u.UserName == requestContext.HttpContext.User.Identity.Name).FirstOrDefault();

            return base.BeginExecute(requestContext, callback, state);
        }
    }
}