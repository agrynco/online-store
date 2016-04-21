using System;
using OS.Business.Domain;
using OS.DAL.Abstract;

namespace OS.Business.Logic
{
    public class HtmlContentsBL
    {
        private readonly IHtmlContentsRepository _htmlContentsRepository;

        public HtmlContentsBL(IHtmlContentsRepository htmlContentsRepository)
        {
            _htmlContentsRepository = htmlContentsRepository;
        }

        public void Update(HtmlContent htmlContent)
        {
            if (htmlContent == null)
            {
                throw new ArgumentNullException(nameof(htmlContent));
            }

            if (htmlContent.Id == 0)
            {
                _htmlContentsRepository.Add(htmlContent);
            }
            else
            {
                _htmlContentsRepository.Update(htmlContent);
            }
        }

        public HtmlContent GetByCode(HtmlContentCode htmlContentCode)
        {
            return _htmlContentsRepository.GetByCode(htmlContentCode);
        }

        public HtmlContent GetById(int id)
        {
            return _htmlContentsRepository.GetById(id);
        }
    }
}