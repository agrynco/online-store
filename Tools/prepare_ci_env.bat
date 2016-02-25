@SET DbUpdatesApplierFolder=%CD%\DbUpdatesApplier
@SET DbUpdatesApplier="%DbUpdatesApplierFolder%\CI_Tests_DbUpdateApplier.Console.exe"

REG ADD HKEY_LOCAL_MACHINE\SOFTWARE\frezaopt.com.ua.tests\AppSettings /v dbUpdatesApplierExeName /t REG_SZ /d %DbUpdatesApplier% /f
REG ADD HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\frezaopt.com.ua.Tests\AppSettings /v dbUpdatesApplierExeName /t REG_SZ /d %DbUpdatesApplier% /f

REG ADD HKEY_LOCAL_MACHINE\SOFTWARE\frezaopt.com.ua.tests\ConnectionStrings /v OnlineStore /t REG_SZ /d "Data Source=ci-sql.frezaopt.com.ua;Initial Catalog=ci-frezaopt.com.ua_tests;Persist Security Info=True;User ID=sa;Password=sa;" /f
REG ADD HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\sql.frezaopt.com.ua.tests\ConnectionStrings /v OnlineStore /t REG_SZ /d "Data Source=ci-sql.frezaopt.com.ua;Initial Catalog=ci-frezaopt.com.ua_tests;Persist Security Info=True;User ID=sa;Password=sa;" /f