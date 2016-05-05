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
            const string UK_PRODUCTCATEGORY_PARENT_ID_ORDER_DELETED = "UK_PRODUCTCATEGORY_PARENT_ID_ORDER_DELETED";
            Property(p => p.ParentId).HasColumnAnnotation(IndexAnnotation.AnnotationName,
                new IndexAnnotation(new[]
                    {
                        new IndexAttribute(UK_PRODUCTCATEGORY_PARENT_ID_NAME, 1)
                            {
                                IsUnique = true
                            },
                        new IndexAttribute(UK_PRODUCTCATEGORY_PARENT_ID_ORDER_DELETED, 1)
                            {
                                IsUnique = true
                            }
                    }));

            Property(p => p.Name).IsRequired().HasMaxLength(255).HasColumnAnnotation(IndexAnnotation.AnnotationName,
                new IndexAnnotation(new IndexAttribute(UK_PRODUCTCATEGORY_PARENT_ID_NAME, 2)
                {
                    IsUnique = true
                }));

            Property(p => p.Order).IsRequired().HasColumnAnnotation(IndexAnnotation.AnnotationName,
                new IndexAnnotation(new IndexAttribute(UK_PRODUCTCATEGORY_PARENT_ID_ORDER_DELETED, 2)
                {
                    IsUnique = true,
                }));
            Property(p => p.IsDeleted).IsRequired().HasColumnAnnotation(IndexAnnotation.AnnotationName,
                new IndexAnnotation(new IndexAttribute(UK_PRODUCTCATEGORY_PARENT_ID_ORDER_DELETED, 3)
                {
                    IsUnique = true,
                }));
        }
    }
}