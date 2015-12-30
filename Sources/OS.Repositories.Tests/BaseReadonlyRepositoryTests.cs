using NUnit.Framework;

namespace OS.Repositories.Tests
{
    public class BaseReadonlyRepositoryTests : BaseDbIntegrationTestFixture
    {
        [OneTimeSetUp]
        public void Init()
        {
            ResetDataBase();
        }
    }
}