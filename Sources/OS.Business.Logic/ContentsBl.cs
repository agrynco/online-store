using OS.Business.Domain;
using OS.DAL.Abstract;

namespace OS.Business.Logic
{
    public class ContentsBl
    {
        private readonly IContentsRepository _contentsRepository;

        public ContentsBl(IContentsRepository contentsRepository)
        {
            _contentsRepository = contentsRepository;
        }
    }
}