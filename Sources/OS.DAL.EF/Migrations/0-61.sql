 -- Start checking possibility of using
 DECLARE @newDbVersion       VARCHAR(11)
 SET @newDbVersion = '0.61'
 
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

DECLARE @tableIds TABLE(Id INT)

INSERT INTO @tableIds
SELECT WaterMarked_Id
FROM   Photos
WHERE  WaterMarked_Id IS NOT NULL

SELECT *
FROM   @tableIds

UPDATE Photos
SET    WaterMarked_Id = NULL

DELETE 
FROM   Files
WHERE  Id IN (SELECT id
              FROM   @tableIds)
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
     SET @newDbVersion = '0.61'
     BEGIN
         EXEC AppendDbVersionInfo @newDbVersion, 'OS-369 overhauls watermark'
         
         PRINT 'Completed successfully'
     END
 END
 GO
 -- End writing new version info