 -- Start checking possibility of using
 DECLARE @newDbVersion       VARCHAR(11)
 SET @newDbVersion = '0.59'
 
 DECLARE @currentDbVersion       VARCHAR(11)
 SET @currentDbVersion = dbo.GetCurrentDbVersionAsString()
 
 DECLARE @errorMessage NVARCHAR(500);
 
 IF dbo.CompareDbVersionWithCurrent(@newDbVersion) <> 1
 BEGIN
     SET @errorMessage = 'Cannot install script ' + @newDbVersion + '. DB version ' + @currentDbVersion + ' expected.'
     RAISERROR(@errorMessage, 20, -1) WITH LOG
 END
 GO
 -- End checking possibility of using
 
 -- BEGIN CHANGES
  UPDATE Products SET [Description] = REPLACE([Description], 'http://allvent.com.ua/api/photos/',
	'/api/photos/') WHERE [Description] like '%http://allvent.com.ua/api/photos/%'
 -- END CHANGES
 
 -- Start writing new version info 
 GO
 IF @@ERROR <> 0
 BEGIN
     
     DECLARE @errorMessage VARCHAR(MAX)
     SET @errorMessage = ERROR_MESSAGE()
     RAISERROR(@errorMessage, 16, 1)
 END
 ELSE
 BEGIN
     DECLARE @newDbVersion       varchar(11)
     SET @newDbVersion = '0.59'
     BEGIN
         EXEC AppendDbVersionInfo @newDbVersion, 'OS-365 Early added images to the products are not visible for now'
         
         PRINT 'Completed successfully'
     END
 END
 GO
 -- End writing new version info