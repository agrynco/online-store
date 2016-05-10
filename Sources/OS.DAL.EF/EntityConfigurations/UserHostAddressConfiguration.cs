using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using OS.Business.Domain;

namespace OS.DAL.EF.EntityConfigurations
{
    public class UserHostAddressConfiguration : EntityTypeConfiguration<UserHostAddress>
    {
        public UserHostAddressConfiguration()
        {
            Property(p => p.IpAddress).IsRequired().HasMaxLength(15).HasColumnAnnotation(IndexAnnotation.AnnotationName,
                new IndexAnnotation(new IndexAttribute("UK_UserHostAddressIpAddress")
                {
                    IsUnique = true
                }));
        }
    }
}