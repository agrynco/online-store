using System.Web.Mvc;
using OS.Business.Logic;

namespace OS.Web.Controllers.Administration
{
    public class CountriesController : BaseAdminController
    {
        private readonly CountriesBL _countriesBL;

        public CountriesController(CountriesBL countriesBL)
        {
            _countriesBL = countriesBL;
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}