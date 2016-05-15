using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using OS.Business.Domain;

namespace OS.DAL.EF.EntityConfigurations
{
    public class HtmlContentConfiguration : EntityTypeConfiguration<HtmlContent>
    {
        public HtmlContentConfiguration()
        {
            Property(entity => entity.Code).IsRequired().HasColumnAnnotation(IndexAnnotation.AnnotationName,
                new IndexAnnotation(new IndexAttribute("UK_HtmlContentCode")
                {
                    IsUnique = true
                }));
        }
    }
}