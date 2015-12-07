using System.Data.Entity;
using OS.Business.Domain;
using OS.DAL.EF.Core;

namespace OS.DAL.EF.Repositories
{
    public class BaseOnlineStoreCRUDRepository<TEntity> : BaseCRUDRepository<EntityFrameworkDbContext, TEntity, int> 
        where TEntity : Entity<int>
    {
        public override void Delete(TEntity entity)
        {
            entity.IsDeleted = true;
            Update(entity);
        }

        public BaseOnlineStoreCRUDRepository(EntityFrameworkDbContext entityFrameworkDbContext) : base(entityFrameworkDbContext)
        {
        }
    }
}