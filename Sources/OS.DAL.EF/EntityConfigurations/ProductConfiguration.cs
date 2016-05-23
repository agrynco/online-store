using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using OS.Business.Domain;

namespace OS.DAL.EF.EntityConfigurations
{
    public class ProductConfiguration : EntityTypeConfiguration<Product>
    {
        public ProductConfiguration()
        {
            Property(p => p.Name).IsRequired().HasMaxLength(255).HasColumnAnnotation(IndexAnnotation.AnnotationName,
                new IndexAnnotation(new IndexAttribute("UK_ProductName")
                    {
                        IsUnique = true
                    }));

            Property(p => p.ShortDescription).IsRequired().HasMaxLength(100);

            Property(p => p.Code).IsRequired().HasMaxLength(25).HasColumnAnnotation(IndexAnnotation.AnnotationName,
                new IndexAnnotation(new IndexAttribute("UK_ProductCode")
                    {
                        IsUnique = true
                    }));

            HasRequired(p => p.CurrencyOfThePrice).WithMany().HasForeignKey(p => p.CurrencyIdOfThePrice);
        }
    }
}