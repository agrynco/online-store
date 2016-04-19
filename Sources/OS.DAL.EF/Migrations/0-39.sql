-- Start checking possibility of using
DECLARE @newDbVersion       VARCHAR(11)
SET @newDbVersion = '0.39'

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
INSERT INTO Contents
  (
    Code,
    NAME,
    IsDeleted,
    Created,
    Updated,
    [Deleted]
  )
VALUES
  (
    2,
    N'Text',
    0,
    GETDATE(),
    NULL,
    NULL
  )
  
INSERT INTO ContentTypes
(
	Code,
	Name,
	IsDeleted,
	Created,
	Updated,
	[Deleted]
)
VALUES
(
	3,
	'Html',
	0,
	GETDATE(),
	NULL,
	NULL
)

INSERT INTO ContentContentTypes
(
	ContentTypeId,
	ContentId,
	Id,
	IsDeleted,
	Created,
	Updated,
	[Deleted]
)
VALUES
(
	(SELECT Id FROM ContentTypes WHERE [Name] = 'Html'),
	(SELECT Id FROM Contents WHERE [Name] = 'Text'),
	3,
	0,
	GETDATE(),
	NULL,
	NULL
)
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
    SET @newDbVersion = '0.39'
    BEGIN
        EXEC AppendDbVersionInfo @newDbVersion, ''
        
        PRINT 'Completed successfully'
    END
END
GO
-- End writing new version info