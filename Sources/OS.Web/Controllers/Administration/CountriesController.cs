﻿using System.Web.Mvc;

namespace OS.Web.Controllers.Administration
{
    public class CountriesController : BaseAdminController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}