-- Start checking possibility of using
DECLARE @newDbVersion       VARCHAR(11)
SET @newDbVersion = '0.53'

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
DELETE FROM Files WHERE id NOT IN(
SELECT ProductPhotos.Id FROM ProductPhotos
UNION 
SELECT WaterMarked_Id FROM ProductPhotos WHERE WaterMarked_Id IS NOT NULL)
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
    SET @newDbVersion = '0.53'
    BEGIN
        EXEC AppendDbVersionInfo @newDbVersion, 'OS-335 (delete redundant Files) After refresh list of products (public list) count of iles increased every time but must only once'
        
        PRINT 'Completed successfully'
    END
END
GO
-- End writing new version info