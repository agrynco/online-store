using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using OS.Business.Domain;
using OS.Business.Logic;
using OS.Web.Models.CountryViewModel;

namespace OS.Web.Controllers.Api
{
    [RoutePrefix("api/countries")]
    public class CountriesController : ApiController
    {
        private readonly CountriesBL _countriesBL;

        public CountriesController(CountriesBL countriesBL)
        {
            _countriesBL = countriesBL;
        }

        [Route("autocomplete")]
        public List<string> Get(string term)
        {
            return _countriesBL.Find(term).Select(c => c.Name).ToList();
        }

        [Route("search")]
        [HttpGet]
        public List<string> Search(string term, [FromUri] Guid[] exclude, int take = 20)
        {
            throw new NotImplementedException();
        }

        [Route]
        public CountryListViewModel GetAll()
        {
            return new CountryListViewModel
                {
                    data = _countriesBL.GetAll()
                };
        }

        [Route("{id}")]
        public void PutName(int id, string name)
        {
            Country country = _countriesBL.GetById(id);
            country.Name = name;
            _countriesBL.Update(country);
        }
    }
}