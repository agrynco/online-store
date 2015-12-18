SET domainName=dev.online-store.grynco.com.ua
SET currentDir=%CD%

CD "%currentDir%\..\Sources\OS.Web"
SET sitePath="%CD%"

CD "%currentDir%"

CALL setup_site.bat %domainName% %sitePath%

REG ADD HKEY_LOCAL_MACHINE\SOFTWARE\OnlineStore\ConnectionStrings /v OnlineStore /t REG_SZ /d "Data Source=OnlineStoreDbSrv;Initial Catalog=DevOnlineStore;Persist Security Info=True;User ID=sa;Password=sa;"
REG ADD HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\OnlineStore\ConnectionStrings /v OnlineStore /t REG_SZ /d "Data Source=OnlineStoreDbSrv;Initial Catalog=DevOnlineStore;Persist Security Info=True;User ID=sa;Password=sa;"

REG ADD HKEY_LOCAL_MACHINE\SOFTWARE\OnlineStore\AppSettings /v ApplicationEnvironment /t REG_SZ /d "Development"
REG ADD HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\OnlineStore\AppSettings /v ApplicationEnvironment /t REG_SZ /d "Development"

CALL _setup_unit_tests.bat