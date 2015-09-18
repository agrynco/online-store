#region Usings
using System.Text;
using AGrynCo.Lib;
using AGrynCo.Lib.Settings;
using OS.Common;
#endregion

namespace OS.Configuration
{
    public class ApplicationSettings : BaseSingletone<ApplicationSettings>
    {
        protected ApplicationSettings()
        {
            DbSettings = new DbSettingsContainer();
            AppSettings = new ApplicationSettingsContainer();
        }

        public DbSettingsContainer DbSettings { get; private set; }
        public ApplicationSettingsContainer AppSettings { get; private set; }

        public class ApplicationSettingsContainer : BaseClass
        {
            public ApplicationEnvironment Environment
            {
                get { return SettingsManager.Instance.GetAppSetting<ApplicationEnvironment>("ApplicationEnvironment"); }
            }
        }

        public class DbSettingsContainer : BaseClass
        {
            public string ApplicationConnectionString
            {
                get { return SettingsManager.Instance.GetConnectionString("OnlineStore"); }
            }

            public override string ToString()
            {
                StringBuilder stringBuilder = new StringBuilder();

                stringBuilder.Append(PropertyMapper<DbSettingsContainer>.PropertyName(t => t.ApplicationConnectionString));
                stringBuilder.Append(" = " + ConnectionStringEncoder.Encode(ApplicationConnectionString));

                return stringBuilder.ToString();
            }
        }
    }
}