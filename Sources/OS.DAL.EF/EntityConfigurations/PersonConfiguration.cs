using System.Data.Entity.ModelConfiguration;
using OS.Business.Domain;

namespace OS.DAL.EF.EntityConfigurations
{
    public class PersonConfiguration : EntityTypeConfiguration<Person>
    {
        public PersonConfiguration()
        {
            Property(p => p.FirstName).IsRequired().HasMaxLength(255);
            Property(p => p.LastName).IsRequired().HasMaxLength(255);
            Property(p => p.MiddleName).HasMaxLength(255);
        }
    }
}