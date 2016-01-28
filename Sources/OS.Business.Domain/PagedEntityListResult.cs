using System.Collections.Generic;

namespace OS.Business.Domain
{
    public class PagedEntityListResult<TEntity, TEntityId> where TEntity : Entity<TEntityId>
    {
        public PagedEntityListResult()
        {
            Entities = new List<TEntity>();
        }

        public List<TEntity> Entities { get; private set; }

        public int TotalRecords { get; set; }
    }
}