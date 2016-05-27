using System.Web.Mvc;
using OS.Business.Domain;
using OS.Business.Logic;
using OS.Web.Models.CurrencyViewModels;

namespace OS.Web.Controllers.Administration
{
    public class CurrenciesController : BaseAdminController
    {
        private readonly CountriesBL _countriesBL;
        private readonly CurrenciesBL _currenciesBL;

        public CurrenciesController(CurrenciesBL currenciesBL, CountriesBL countriesBL)
        {
            _currenciesBL = currenciesBL;
            _countriesBL = countriesBL;
        }

        [Route("administration/currencies")]
        public ActionResult Index()
        {
            return View();
        }

        [Route("administration/currencies/edit/{id}")]
        public ActionResult Edit(int id)
        {
            Currency currency = _currenciesBL.Get(id);
            return View(new CurrencyCreateOrEditViewModel
                {
                    Id = currency.Id,
                    IsMain = currency.IsMain,
                    Symbol = currency.Symbol,
                    Code = currency.Code,
                    CodeISO = currency.CodeISO,
                    CountryId = currency.CountryId,
                    HexSymbol = currency.HexSymbol,
                    Countries = _countriesBL.GetAll(),
                    Name = currency.Name
                });
        }

        private void AssignModelToCurrency(CurrencyCreateOrEditViewModel source, Currency destination)
        {
            destination.Code = source.Code;
            destination.CodeISO = source.CodeISO;
            destination.CountryId = source.CountryId;
            destination.HexSymbol = source.HexSymbol;
            destination.Symbol = source.Symbol;
            destination.Name = source.Name;
            destination.IsMain = source.IsMain;
        }

        [HttpGet]
        public ActionResult Create()
        {
            CurrencyCreateOrEditViewModel model = new CurrencyCreateOrEditViewModel();

            model.Countries = _countriesBL.GetAll();

            return View("Edit", model);
        }

        public ActionResult Save(CurrencyCreateOrEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Currency currency;
                if (model.Id.HasValue)
                {
                    currency = _currenciesBL.Get(model.Id.Value);

                    AssignModelToCurrency(model, currency);
                    _currenciesBL.Update(currency);
                }
                else
                {
                    currency = new Currency();
                    AssignModelToCurrency(model, currency);
                    _currenciesBL.Add(currency);
                }

                return RedirectToAction("Index");
            }

            model.Countries = _countriesBL.GetAll();
            return View("Edit", model);
        }
    }
}