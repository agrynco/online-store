CALL _prepare-unit-tests_dbupdatesapplier.bat

REG ADD HKEY_LOCAL_MACHINE\SOFTWARE\OnlineStore.Tests\ConnectionStrings /v OnlineStore /t REG_SZ /d "Data Source=OnlineStoreDbSrv;Initial Catalog=CiOnlineStore_Tests;Persist Security Info=True;User ID=sa;Password=sa;" /f
REG ADD HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\OnlineStore.Tests\ConnectionStrings /v OnlineStore /t REG_SZ /d "Data Source=OnlineStoreDbSrv;Initial Catalog=CiOnlineStore_Tests;Persist Security Info=True;User ID=sa;Password=sa;" /f