#region Usings
using System.Data.Entity;
#endregion

namespace OS.DAL.EF.Core
{
    public class BaseRepository<TDbContext> where TDbContext : DbContext
    {
        private readonly TDbContext _entityFrameworkDbContext;

        public BaseRepository(TDbContext entityFrameworkDbContext)
        {
            _entityFrameworkDbContext = entityFrameworkDbContext;
        }

        protected TDbContext EntityFrameworkDbContext
        {
            get { return _entityFrameworkDbContext; }
        }
    }
}