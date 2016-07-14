using System;
using OS.Business.Domain;

namespace OS.Business.Logic.Exceptions
{
    public class OrderNotificationMessageTextBuildException : BaseBusinessException
    {
        public OrderNotificationMessageTextBuildException(Order order, Exception innerException)
            : base($"Can not build message text for the order {order}", innerException)
        {
        }
    }
}