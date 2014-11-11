namespace Lekarite.Mvc.Controllers
{
    using System.Web.Mvc;

    using Lekarite.Data.Interfaces;

    public class BaseController : Controller
    {
        public BaseController(ILekariteData data)
        {
            this.Data = data;
        }

        protected ILekariteData Data { get; set; }
    }
}