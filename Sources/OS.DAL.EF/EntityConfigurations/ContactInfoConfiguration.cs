using System.Data.Entity.ModelConfiguration;
using OS.Business.Domain;

namespace OS.DAL.EF.EntityConfigurations
{
    public class ContactInfoConfiguration : EntityTypeConfiguration<ContactInfo>
    {
        public ContactInfoConfiguration()
        {
            ToTable("ContactInfos");
        }
    }
}