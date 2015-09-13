#region Usings
using System.Data.Entity;
#endregion

namespace OS.DAL.EF.Core
{
    public class BaseRepository<TDbContext> where TDbContext : DbContext
    {
        private readonly TDbContext _dbContext;

        public BaseRepository(TDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        protected TDbContext DbContext
        {
            get { return _dbContext; }
        }
    }
}