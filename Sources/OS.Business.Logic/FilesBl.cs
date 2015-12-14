using OS.Business.Domain;
using OS.DAL.Abstract;

namespace OS.Business.Logic
{
    public class FilesBL
    {
        private readonly IFilesRepository _filesRepository;

        public FilesBL(IFilesRepository filesRepository)
        {
            _filesRepository = filesRepository;
        }

        public File GetFile(int id)
        {
            return _filesRepository.GetById(id);
        }
    }
}