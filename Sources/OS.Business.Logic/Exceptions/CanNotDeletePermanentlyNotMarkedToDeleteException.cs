using OS.Business.Domain;

namespace OS.Business.Logic.Exceptions
{
    public class CanNotDeletePermanentlyNotMarkedToDeleteException : BaseBusinessException
    {
        public CanNotDeletePermanentlyNotMarkedToDeleteException(IEntity entity) :  base(string.Format("Type: '{0}'; Id: {1}",
            entity.GetType(), entity.Id))
        {
        }
    }
}