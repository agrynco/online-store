using System.Collections;
using Elmah;
using OS.Configuration;

namespace OS.Web
{
    public class OsSqlErrorLog : SqlErrorLog
    {
        public OsSqlErrorLog(IDictionary config) : base(config)
        {
        }

        public OsSqlErrorLog(string connectionString) : base(connectionString)
        {
        }

        public override string ConnectionString { get { return ApplicationSettings.Instance.DbSettings.ApplicationConnectionString; } }
    }
}