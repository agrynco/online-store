using System.Linq;
using System.Web.Mvc;
using OS.Business.Domain;
using OS.Business.Logic;
using OS.Web.Models.CurrencyRateViewModels;

namespace OS.Web.Controllers.Administration
{
    [RoutePrefix("administration/currencyrates")]
    public class CurrencyRatesController : BaseAdminController
    {
        private readonly CurrenciesBL _currenciesBL;
        private readonly CurrencyRatesBL _currencyRatesBL;

        public CurrencyRatesController(CurrencyRatesBL currencyRatesBL, CurrenciesBL currenciesBL)
        {
            _currencyRatesBL = currencyRatesBL;
            _currenciesBL = currenciesBL;
        }


        [Route]
        public ActionResult Index()
        {
            return View();
        }

        [Route("edit/{id}")]
        public ActionResult Edit(int id)
        {
            CurrencyRate currencyRate = _currencyRatesBL.Get(id);
            CurrencyRateCreateOrEditViewModel model = new CurrencyRateCreateOrEditViewModel
                {
                    MainCurrency = _currenciesBL.GetMainCurrency(),
                    Id = id,
                    Rate = currencyRate.Rate,
                    CurrencyId = currencyRate.CurrencyId,
                    Currencies = _currenciesBL.GetAll().Where(currency => !currency.IsMain).ToList()
                };

            return View(model);
        }

        private void AssignModelToCurrencyRate(CurrencyRateCreateOrEditViewModel source, CurrencyRate destination)
        {
            destination.Rate = source.Rate;
            destination.CurrencyId = source.CurrencyId.Value;
        }

        [HttpGet]
        [Route("create")]
        public ActionResult Create()
        {
            CurrencyRateCreateOrEditViewModel model = new CurrencyRateCreateOrEditViewModel();

            model.Currencies = _currenciesBL.GetAll().Where(currency => !currency.IsMain).ToList();

            return View("Edit", model);
        }

        public ActionResult Save(CurrencyRateCreateOrEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                CurrencyRate currencyRate;
                if (model.Id.HasValue)
                {
                    currencyRate = _currencyRatesBL.Get(model.Id.Value);

                    AssignModelToCurrencyRate(model, currencyRate);
                    _currencyRatesBL.Update(currencyRate);
                }
                else
                {
                    currencyRate = new CurrencyRate();
                    AssignModelToCurrencyRate(model, currencyRate);
                    _currencyRatesBL.Add(currencyRate);
                }

                return RedirectToAction("Index");
            }

            model.Currencies = _currenciesBL.GetAll().Where(currency => !currency.IsMain).ToList();
            return View("Edit", model);
        }
    }
}