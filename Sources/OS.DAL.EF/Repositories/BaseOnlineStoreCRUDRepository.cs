using System.Data.Entity;
using System.Linq;
using OS.Business.Domain;
using OS.DAL.EF.Core;

namespace OS.DAL.EF.Repositories
{
    public class BaseOnlineStoreCRUDRepository<TEntity> : BaseCRUDRepository<EntityFrameworkDbContext, TEntity, int> 
        where TEntity : Entity<int>
    {
        public override void Delete(params TEntity[] entities)
        {
            foreach (TEntity entity in entities)
            {
                entity.IsDeleted = true;
                Update(entity);
            }
        }

        public override IQueryable<TEntity> GetAll()
        {
            return base.GetAll().Where(entity => entity.IsDeleted == false);
        }

        public BaseOnlineStoreCRUDRepository(EntityFrameworkDbContext entityFrameworkDbContext) : base(entityFrameworkDbContext)
        {
        }
    }
}