using System.Data.Entity.ModelConfiguration;
using OS.Business.Domain;

namespace OS.DAL.EF.EntityConfigurations
{
    public class OrderConfiguration : EntityTypeConfiguration<Order>
    {
        public OrderConfiguration()
        {
        }
    }
}