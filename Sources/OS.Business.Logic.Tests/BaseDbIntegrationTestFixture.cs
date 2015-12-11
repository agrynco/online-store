using System.Diagnostics;
using System.IO;
using OS.Configuration;
using OS.DAL.EF;
using OS.Dependency;
using SimpleInjector;

namespace OS.Business.Logic.Tests
{
    public class BaseDbIntegrationTestFixture
    {
        protected BaseDbIntegrationTestFixture()
        {
            Container container = new Container();
            DI.Configure(container);

            EntityFrameworkDbContext = DI.Resolve<EntityFrameworkDbContext>();
        }

        protected static void ResetDataBase()
        {
            Process process = new Process();
            string workingDirectory = new FileInfo(ApplicationSettings.Instance.TestsSettings.DbUpdatesApplierExeName).DirectoryName;
            Debug.Assert(workingDirectory != null, "workingDirectory != null");

            ProcessStartInfo processStartInfo = new ProcessStartInfo
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                FileName = ApplicationSettings.Instance.TestsSettings.DbUpdatesApplierExeName,
                WorkingDirectory = workingDirectory,
                Arguments = "fromScratch=true"
            };
            process.StartInfo = processStartInfo;
            process.Start();
            process.WaitForExit();
            if (process.ExitCode != 0)
            {
                throw new ResetDatabaseException(string.Format("Error during executing {0}. Error code equals {1}", 
                    ApplicationSettings.Instance.TestsSettings.DbUpdatesApplierExeName, process.ExitCode));
            }
        }

        protected EntityFrameworkDbContext EntityFrameworkDbContext { get; private set; }
    }
}