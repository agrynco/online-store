using System;
using OS.Common;

namespace OS.Logging
{
    public class ElmahLogger : ILogger
    {
        public void Error(Exception exception)
        {
            Elmah.ErrorSignal.FromCurrentContext().Raise(exception);
        }
    }
}