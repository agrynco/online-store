using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using OS.Business.Domain;

namespace OS.DAL.EF.EntityConfigurations
{
    public class ProductViewingInfoConfiguration : EntityTypeConfiguration<ProductViewingInfo>
    {
        public ProductViewingInfoConfiguration()
        {
            const string UK_PRODUCTID_USERHOSTADDRESSID = "UK_ProductIdUserHostAddressId";
            Property(p => p.ProductId).HasColumnAnnotation(IndexAnnotation.AnnotationName,
                new IndexAnnotation(new[]
                    {
                        new IndexAttribute(UK_PRODUCTID_USERHOSTADDRESSID, 1)
                            {
                                IsUnique = true
                            }
                    }));

            Property(p => p.UserHostAddressId).HasColumnAnnotation(IndexAnnotation.AnnotationName,
                new IndexAnnotation(new[]
                    {
                        new IndexAttribute(UK_PRODUCTID_USERHOSTADDRESSID, 2)
                            {
                                IsUnique = true
                            }
                    }));
        }
    }
}