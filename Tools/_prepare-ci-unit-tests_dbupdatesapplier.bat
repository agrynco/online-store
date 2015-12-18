@SET DbUpdatesApplierFolder=%CD%\DbUpdatesApplier
@SET DbUpdatesApplier="%DbUpdatesApplierFolder%\CI_Tests_DbUpdateApplier.Console.exe"

REG ADD HKEY_LOCAL_MACHINE\SOFTWARE\OnlineStore.Tests\AppSettings /v dbUpdatesApplierExeName /t REG_SZ /d %DbUpdatesApplier% /f
REG ADD HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\OnlineStore.Tests\AppSettings /v dbUpdatesApplierExeName /t REG_SZ /d %DbUpdatesApplier% /f