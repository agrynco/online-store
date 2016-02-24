@SET DbUpdatesApplierFolder=%CD%\DbUpdatesApplier
@SET DbUpdatesApplier="%DbUpdatesApplierFolder%\CI_Tests_DbUpdateApplier.Console.exe"

REG ADD HKEY_LOCAL_MACHINE\SOFTWARE\allvent.com.ua.tests\AppSettings /v dbUpdatesApplierExeName /t REG_SZ /d %DbUpdatesApplier% /f
REG ADD HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\OnlineStore.Tests\AppSettings /v dbUpdatesApplierExeName /t REG_SZ /d %DbUpdatesApplier% /f

REG ADD HKEY_LOCAL_MACHINE\SOFTWARE\allvent.com.ua.tests\ConnectionStrings /v OnlineStore /t REG_SZ /d "Data Source=ci-sql.allvent.com.ua;Initial Catalog=ci-allvent.com.ua_tests;Persist Security Info=True;User ID=sa;Password=sa;" /f
REG ADD HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\allvent.com.ua.tests\ConnectionStrings /v OnlineStore /t REG_SZ /d "Data Source=ci-sql.allvent.com.ua;Initial Catalog=ci-allvent.com.ua_tests;Persist Security Info=True;User ID=sa;Password=sa;" /f