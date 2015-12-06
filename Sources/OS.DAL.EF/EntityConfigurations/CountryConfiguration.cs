using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using OS.Business.Domain;

namespace OS.DAL.EF.EntityConfigurations
{
    public class CountryConfiguration : EntityTypeConfiguration<Country>
    {
        public CountryConfiguration()
        {
            Property(p => p.Name).IsRequired().HasMaxLength(50).HasColumnAnnotation(IndexAnnotation.AnnotationName,
                new IndexAnnotation(new IndexAttribute("UK_CountryName")
                {
                    IsUnique = true
                }));

            Property(p => p.ISO).IsRequired().HasMaxLength(3).IsFixedLength().HasColumnAnnotation(IndexAnnotation.AnnotationName,
                new IndexAnnotation(new IndexAttribute("UK_CountryISOCode")
                {
                    IsUnique = true
                }));

            Property(p => p.TwoCharsCode).IsRequired().HasMaxLength(2).IsFixedLength().HasColumnAnnotation(IndexAnnotation.AnnotationName,
                new IndexAnnotation(new IndexAttribute("UK_CountryTwoCharsCode")
                {
                    IsUnique = true
                }));

            Property(p => p.ThreeCharsCode).IsRequired().HasMaxLength(3).IsFixedLength().HasColumnAnnotation(IndexAnnotation.AnnotationName,
                new IndexAnnotation(new IndexAttribute("UK_CountryThreeCharsCode")
                {
                    IsUnique = true
                }));

            Property(p => p.EnglishName).IsRequired().HasMaxLength(50).HasColumnAnnotation(IndexAnnotation.AnnotationName,
                new IndexAnnotation(new IndexAttribute("UK_CountryEnglishName")
                {
                    IsUnique = true
                }));
        }
    }
}