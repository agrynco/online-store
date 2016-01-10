using System.Data.Entity.ModelConfiguration;
using OS.Business.Domain;

namespace OS.DAL.EF.EntityConfigurations
{
    public class BuyerConfiguration : EntityTypeConfiguration<Buyer>
    {
        public BuyerConfiguration()
        {
            Property(p => p.PersonId).IsRequired();
        }
    }
}