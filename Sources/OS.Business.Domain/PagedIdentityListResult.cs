namespace OS.Business.Domain
{
    public class PagedIdentityListResult<TEntity> : PagedEntityListResult<TEntity, int> where TEntity : Entity<int>
    {
    }
}