#region Usings
using System.Collections.Generic;
using System.Web.Mvc;
using OS.Business.Domain;
using OS.Business.Logic;
#endregion

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

        public ActionResult Update()
        {
            List<Country> onlineCountries = _countriesBL.GetOnlineCountries();
            UpdateCountriesResult updateCountriesResult = _countriesBL.UpdateCountries(onlineCountries);

            return View(updateCountriesResult);
        }
    }
}