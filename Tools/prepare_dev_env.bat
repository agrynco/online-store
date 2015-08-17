SET domainName=dev.online-store.grynco.com.ua
SET currentDir=%CD%

CD "%currentDir%\..\Sources\Web"
SET sitePath="%CD%"

CD "%currentDir%"

CALL setup_site.bat %domainName% %sitePath%