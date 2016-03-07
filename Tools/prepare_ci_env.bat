@SET DbUpdatesApplierFolder=%CD%\DbUpdatesApplier
@SET DbUpdatesApplier="%DbUpdatesApplierFolder%\CI_Tests_DbUpdateApplier.Console.exe"

REG ADD HKEY_LOCAL_MACHINE\SOFTWARE\OnlineStore.Tests\AppSettings /v dbUpdatesApplierExeName /t REG_SZ /d %DbUpdatesApplier% /f
REG ADD HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\OnlineStore.Tests\AppSettings /v dbUpdatesApplierExeName /t REG_SZ /d %DbUpdatesApplier% /f


REG ADD HKEY_LOCAL_MACHINE\SOFTWARE\OnlineStore.Tests\ConnectionStrings /v OnlineStore /t REG_SZ /d "Data Source=OnlineStoreDbSrv;Initial Catalog=CiOnlineStore_Tests;Persist Security Info=True;User ID=sa;Password=sa;" /f
REG ADD HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\OnlineStore.Tests\ConnectionStrings /v OnlineStore /t REG_SZ /d "Data Source=OnlineStoreDbSrv;Initial Catalog=CiOnlineStore_Tests;Persist Security Info=True;User ID=sa;Password=sa;" /f