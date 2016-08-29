using System.Collections.Generic;
using System.Linq;
using OS.Business.Domain;
using OS.DAL.Abstract;

namespace OS.Business.Logic
{
    public class TextContentsBL
    {
        private readonly ITextContentsRepository _textContentsRepository;

        public TextContentsBL(ITextContentsRepository textContentsRepository)
        {
            _textContentsRepository = textContentsRepository;
        }

        public List<TextContent> GetAll()
        {
            return _textContentsRepository.GetAll().ToList();
        }

        public TextContent Get(TextContentCode code)
        {
            return _textContentsRepository.GetAll().SingleOrDefault(content => content.Code == code);
        }

        public void Update(TextContent content)
        {
            _textContentsRepository.Update(content);
        }

        public TextContent Add(TextContent content)
        {
            return _textContentsRepository.Add(content);
        }

        public void Delete(TextContentCode code)
        {
            _textContentsRepository.Delete(Get(code));
        }
    }
}