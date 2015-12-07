using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using HtmlAgilityPack;
using OS.Business.Domain;
using OS.Common;
using OS.DAL.Abstract;

namespace OS.Business.Logic
{
    public class CountriesBL
    {
        private readonly ICountriesRepository _countriesRepository;

        public CountriesBL(ICountriesRepository countriesRepository)
        {
            _countriesRepository = countriesRepository;
        }

        public List<Country> GetOnlineCountries()
        {
            var htmlDocument = new HtmlDocument();

            WebClient webClient = new WebClient();
            webClient.Encoding = Encoding.UTF8;
            string html = webClient.DownloadString("http://whoyougle.ru/place/countries/list");

            htmlDocument.LoadHtml(html);

            HtmlNode countriesTableBody = htmlDocument.DocumentNode.SelectSingleNode("//*[@id=\"content\"]/div[2]/table/tbody");
            IEnumerable<HtmlNode> rows = countriesTableBody.ChildNodes.Where(n => n.Name == "tr");

            List<Country> result = new List<Country>();
            foreach (HtmlNode row in rows)
            {
                var cells = row.ChildNodes.Where(n => n.Name == "td").ToList();
                string isoCode = cells[6].InnerText;
                if (!string.IsNullOrEmpty(isoCode))
                {
                    result.Add(new Country
                        {
                            Name = cells[1].ChildNodes.Single(n => n.Name == "a").InnerText,
                            EnglishName = cells[2].InnerText,
                            TwoCharsCode = cells[4].InnerText,
                            ThreeCharsCode = cells[5].InnerText,
                            ISO = isoCode,
                            PhoneCode = cells[7].InnerText
                        });
                }
            }

            return result;
        }
        public UpdateCountriesResult UpdateCountries(List<Country> newCountries)
        {
            List<Country> existedCountries = _countriesRepository.GetAll().ToList();

            UpdateCountriesResult result = new UpdateCountriesResult
                {
                    Updated = newCountries.Intersect(existedCountries, new KeyEqualityComparer<Country>(o => o.EnglishName)).ToList(),
                    Created = newCountries.Except(existedCountries, new KeyEqualityComparer<Country>(o => o.EnglishName)).ToList(),
                    Deleted = existedCountries.Except(newCountries, new KeyEqualityComparer<Country>(o => o.EnglishName)).ToList()
                };

            result.Updated.ForEach(item => _countriesRepository.Update(item));
            result.Created.ForEach(item => _countriesRepository.Add(item));
            result.Deleted.ForEach(item => _countriesRepository.Delete(item));

            return result;
        }
    }
}