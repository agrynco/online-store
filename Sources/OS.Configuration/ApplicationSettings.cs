#region Usings
using AGrynCo.Lib;
using AGrynCo.Lib.Settings;
#endregion

namespace OS.Configuration
{
    public class ApplicationSettings : BaseSingletone<ApplicationSettings>
    {
        protected ApplicationSettings()
        {
            DbSettings = new DbSettingsContainer();
        }

        public DbSettingsContainer DbSettings { get; private set; }

        public class ApplicationSettingsContainer
        {
        }

        public class DbSettingsContainer
        {
            public string ApplicationConnectionString
            {
                get { return SettingsManager.Instance.GetConnectionString("OnlineStore"); }
            }
        }
    }
}