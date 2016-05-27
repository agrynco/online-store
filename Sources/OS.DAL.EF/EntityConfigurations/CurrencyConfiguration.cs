using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using OS.Business.Domain;

namespace OS.DAL.EF.EntityConfigurations
{
    public class CurrencyConfiguration : EntityTypeConfiguration<Currency>
    {
        public CurrencyConfiguration()
        {
            Property(p => p.Name).IsRequired().HasMaxLength(150).HasColumnAnnotation(IndexAnnotation.AnnotationName,
                new IndexAnnotation(new IndexAttribute("UK_CurrencyName")
                    {
                        IsUnique = true
                    }));

            Property(p => p.Symbol).IsRequired().HasMaxLength(5).HasColumnAnnotation(IndexAnnotation.AnnotationName,
                new IndexAnnotation(new IndexAttribute("UK_CurrencyCodeISO")
                    {
                        IsUnique = true
                    }));
            Property(p => p.Code).HasColumnAnnotation(IndexAnnotation.AnnotationName,
                new IndexAnnotation(new IndexAttribute("UK_CurrencyCode")
                    {
                        IsUnique = true
                    }));
            Property(p => p.CountryId).HasColumnAnnotation(IndexAnnotation.AnnotationName,
                new IndexAnnotation(new IndexAttribute("UK_CurrencyCountryId")
                    {
                        IsUnique = true
                    }));
        }
    }
}