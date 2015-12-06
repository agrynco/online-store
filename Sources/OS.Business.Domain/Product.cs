#region Usings
using System.Collections.Generic;
#endregion

namespace OS.Business.Domain
{
    public class Product : NamedEntity
    {
        public Product()
        {
            Categories = new List<ProductCategory>();
        }

        public string Description { get; set; }
        public decimal Price { get; set; }
        public virtual List<ProductCategory> Categories { get; private set; }
        public virtual Brand Brand { get; set; }
        public virtual Country CountryProducer { get; set; }
    }
}