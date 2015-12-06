using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using OS.Business.Domain;

namespace OS.DAL.EF.EntityConfigurations
{
    public class ProductCategoryConfiguration : EntityTypeConfiguration<ProductCategory>
    {
        public ProductCategoryConfiguration()
        {
            const string UK_PRODUCTCATEGORY_PARENT_ID_NAME = "UK_PRODUCTCATEGORY_PARENT_ID_NAME";
            Property(p => p.ParentId).HasColumnAnnotation(IndexAnnotation.AnnotationName,
                new IndexAnnotation(new IndexAttribute(UK_PRODUCTCATEGORY_PARENT_ID_NAME)
                {
                    IsUnique = true,
                    Order = 1
                }));

            Property(p => p.Name).IsRequired().HasMaxLength(255).HasColumnAnnotation(IndexAnnotation.AnnotationName,
                new IndexAnnotation(new IndexAttribute(UK_PRODUCTCATEGORY_PARENT_ID_NAME)
                {
                    IsUnique = true,
                    Order = 2
                }));
        }
    }
}