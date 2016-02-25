@SET DbUpdatesApplierFolder=%CD%\DbUpdatesApplier
@SET DbUpdatesApplier="%DbUpdatesApplierFolder%\Tests_DbUpdateApplier.Console.exe"

REG ADD HKEY_LOCAL_MACHINE\SOFTWARE\frezaopt.com.ua.Tests\AppSettings /v dbUpdatesApplierExeName /t REG_SZ /d %DbUpdatesApplier% /f
REG ADD HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\frezaopt.com.ua.Tests\AppSettings /v dbUpdatesApplierExeName /t REG_SZ /d %DbUpdatesApplier% /f