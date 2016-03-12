using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using OS.Business.Domain;

namespace OS.DAL.EF.EntityConfigurations
{
    public class EmailTemplateConfiguration : EntityTypeConfiguration<EmailTemplate>
    {
        public EmailTemplateConfiguration()
        {
            Property(p => p.TemplateType).IsRequired().HasColumnAnnotation(IndexAnnotation.AnnotationName,
                new IndexAnnotation(new IndexAttribute("UK_EmailTemplateType")
                    {
                        IsUnique = true
                    }));
        }
    }
}