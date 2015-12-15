#region Usings
using System;
using OS.Business.Domain;
using OS.DAL.Abstract;
#endregion

namespace OS.Business.Logic
{
    public class ContentContentTypesBL
    {
        private readonly IContentsRepository _contentsRepository;
        private readonly IContentTypesRepository _contentTypesRepository;
        private readonly IContentContentTypesRepository _contentContentTypesRepository;

        public ContentContentTypesBL(IContentsRepository contentsRepository, IContentTypesRepository contentTypesRepository,
            IContentContentTypesRepository contentContentTypesRepository)
        {
            _contentsRepository = contentsRepository;
            _contentTypesRepository = contentTypesRepository;
            _contentContentTypesRepository = contentContentTypesRepository;
        }

        public ContentContentType Get(string mimeContentType)
        {
            string[] strings = mimeContentType.Split(new[] {'/'}, StringSplitOptions.RemoveEmptyEntries);

            Content content = _contentsRepository.GetByName(strings[0]);
            ContentType contentType = _contentTypesRepository.GetByName(strings[1]);

            ContentContentType result = _contentContentTypesRepository.Get(content.Id, contentType.Id);

            return result;
        }
    }
}