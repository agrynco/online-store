using System.Diagnostics;
using System.IO;
using OS.Configuration;
using OS.DAL.EF;
using OS.Dependency;

namespace OS.Repositories.Tests
{
    public class BaseDbIntegrationTestFixture
    {
        protected BaseDbIntegrationTestFixture()
        {
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
                throw new ResetDatabaseException($"Error during executing {ApplicationSettings.Instance.TestsSettings.DbUpdatesApplierExeName}. Error code equals {process.ExitCode}");
            }
        }

        protected EntityFrameworkDbContext EntityFrameworkDbContext { get; private set; }
    }
}