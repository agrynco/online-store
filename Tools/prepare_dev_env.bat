SET domainName=dev.allvent.com.ua
SET currentDir=%CD%

CD "%currentDir%\..\Sources\OS.Web"
SET sitePath="%CD%"

CD "%currentDir%"

CALL setup_site.bat %domainName% %sitePath%

REG ADD HKEY_LOCAL_MACHINE\SOFTWARE\allvent.com.ua\ConnectionStrings /v OnlineStore /t REG_SZ /d "Data Source=dev.sql.frezaopt.com.ua;Initial Catalog=dev.frezaopt.com.ua;Persist Security Info=True;User ID=sa;Password=sa;" /f
REG ADD HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\allvent.com.ua\ConnectionStrings /v OnlineStore /t REG_SZ /d "Data Source=dev.sql.frezaopt.com.ua;Initial Catalog=dev.frezaopt.com.ua;Persist Security Info=True;User ID=sa;Password=sa;" /f

REG ADD HKEY_LOCAL_MACHINE\SOFTWARE\frezaopt.com.ua\AppSettings /v ApplicationEnvironment /t REG_SZ /d "Development" /f
REG ADD HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\frezaopt.com.ua\AppSettings /v ApplicationEnvironment /t REG_SZ /d "Development" /f

CALL _setup_unit_tests.bat