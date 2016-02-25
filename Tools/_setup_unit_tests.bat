CALL _prepare-unit-tests_dbupdatesapplier.bat

REG ADD HKEY_LOCAL_MACHINE\SOFTWARE\frezaopt.com.ua.Tests\ConnectionStrings /v OnlineStore /t REG_SZ /d "Data Source=sql.frezaopt.com.ua;Initial Catalog=dev.frezaopt.com.ua_Tests;Persist Security Info=True;User ID=sa;Password=sa;" /f
REG ADD HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\frezaopt.com.ua.Tests\ConnectionStrings /v OnlineStore /t REG_SZ /d "Data Source=sql.frezaopt.com.ua;Initial Catalog=dev.frezaopt.com.ua_Tests;Persist Security Info=True;User ID=sa;Password=sa;" /f