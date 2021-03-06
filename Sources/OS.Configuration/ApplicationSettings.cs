﻿#region Usings
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
            TestsSettings = new TestsSettingsContainer();
            MailServiceSettings = new MailServiceSettingsContainer();
        }

        public ApplicationSettingsContainer AppSettings { get; private set; }

        public DbSettingsContainer DbSettings { get; private set; }

        public MailServiceSettingsContainer MailServiceSettings { get; private set; }
        public TestsSettingsContainer TestsSettings { get; private set; }

        public class ApplicationSettingsContainer : BaseClass
        {
            public string ApplicationName
            {
                get { return SettingsManager.Instance.GetAppSetting("ApplicationName", "Online Store"); }
            }

            public int DefaultPageSize
            {
                get { return SettingsManager.Instance.GetAppSetting("DefaultPageSize", 24); }
            }

            public ApplicationEnvironment Environment
            {
                get { return SettingsManager.Instance.GetAppSetting<ApplicationEnvironment>("ApplicationEnvironment"); }
            }

            public string SeqUrl
            {
                get { return SettingsManager.Instance.GetAppSetting("SeqUrl", "http://127.0.0.1:5341"); }
            }

            public bool UseWatermarks
            {
                get { return SettingsManager.Instance.GetAppSetting("UseWatermarks", true); }
            }
        }

        public class MailServiceSettingsContainer : BaseClass
        {
            private const string _SETTINGS_PREFFIX = "MailServer_";

            public bool EnableSsl
            {
                get { return SettingsManager.Instance.GetAppSetting<bool>(_SETTINGS_PREFFIX + "EnableSsl"); }
            }

            public string FromAddress
            {
                get { return SettingsManager.Instance.GetAppSetting(_SETTINGS_PREFFIX + "FromAddress"); }
            }

            public string FromPassword
            {
                get { return SettingsManager.Instance.GetAppSetting(_SETTINGS_PREFFIX + "FromPassword"); }
            }

            public string Host
            {
                get { return SettingsManager.Instance.GetAppSetting(_SETTINGS_PREFFIX + "Host"); }
            }

            public int Port
            {
                get { return SettingsManager.Instance.GetAppSetting<int>(_SETTINGS_PREFFIX + "Port"); }
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

        public class TestsSettingsContainer : BaseClass
        {
            public string DbUpdatesApplierExeName
            {
                get { return SettingsManager.Instance.GetAppSetting<string>("dbUpdatesApplierExeName"); }
            }
        }
    }
}