using System.Linq;
using OS.Business.Domain;
using OS.DAL.Abstract;
using OS.DAL.Abstract.Exceptions;

namespace OS.DAL.EF.Repositories
{
    public class NamedEntitiesRepository<TNamedEntity> : OnlineStoreCRUDRepository<TNamedEntity>, INamedEntitiesRepository<TNamedEntity> where TNamedEntity : NamedEntity
    {
        public NamedEntitiesRepository(EntityFrameworkDbContext entityFrameworkDbContext) : base(entityFrameworkDbContext)
        {
        }

        public TNamedEntity GetByName(string name)
        {
            TNamedEntity namedEntity = GetAll().SingleOrDefault(entity => entity.Name == name);

            if (namedEntity == null)
            {
                throw new ThereIsNoEntityException(string.Format("There is no {0} with Name = '{1}'", typeof(TNamedEntity), name));
            }

            return namedEntity;
        }
    }
}