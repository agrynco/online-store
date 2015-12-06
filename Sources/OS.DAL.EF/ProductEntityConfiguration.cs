using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using OS.Business.Domain;

namespace OS.DAL.EF
{
    public class ProductEntityConfiguration : EntityTypeConfiguration<Product>
    {
        public ProductEntityConfiguration()
        {
            const string UK_NAME = "UK_NAME";

            Property(p => p.Name).IsRequired().HasColumnAnnotation(IndexAnnotation.AnnotationName,
                new IndexAnnotation(new IndexAttribute(UK_NAME)
                    {
                        IsUnique = true
                    }));
        }
    }
}