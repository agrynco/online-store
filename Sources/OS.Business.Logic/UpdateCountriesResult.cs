using System.Collections.Generic;
using OS.Business.Domain;

namespace OS.Business.Logic
{
    public class UpdateCountriesResult
    {
        public List<Country> Updated { get; set; } 
        public List<Country> Deleted { get; set; } 
        public List<Country> Created { get; set; } 
    }
}