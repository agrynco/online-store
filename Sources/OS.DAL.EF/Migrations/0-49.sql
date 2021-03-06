-- Start checking possibility of using
DECLARE @newDbVersion       VARCHAR(11)
SET @newDbVersion = '0.49'

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
INSERT INTO CurrencyRates
(
	-- Id -- this column value is auto-generated
	CurrencyId,
	Rate,
	IsDeleted,
	Created,
	Updated,
	[Deleted]
)
VALUES
(
	(SELECT Id FROM Currencies WHERE Code = 840),
	25.635,
	0,
	Cast('4/14/2016' AS DATETIME),
	NULL,
	NULL
)

INSERT INTO CurrencyRates
(
	-- Id -- this column value is auto-generated
	CurrencyId,
	Rate,
	IsDeleted,
	Created,
	Updated,
	[Deleted]
)
VALUES
(
	(SELECT Id FROM Currencies WHERE Code = 840),
	25.875,
	0,
	Cast('4/11/2016' AS DATETIME),
	NULL,
	NULL
)

INSERT INTO CurrencyRates
(
	-- Id -- this column value is auto-generated
	CurrencyId,
	Rate,
	IsDeleted,
	Created,
	Updated,
	[Deleted]
)
VALUES
(
	(SELECT Id FROM Currencies WHERE Code = 840),
	26.425,
	0,
	Cast('3/10/2016' AS DATETIME),
	NULL,
	NULL
)

INSERT INTO CurrencyRates
(
	-- Id -- this column value is auto-generated
	CurrencyId,
	Rate,
	IsDeleted,
	Created,
	Updated,
	[Deleted]
)
VALUES
(
	(SELECT Id FROM Currencies WHERE Code = 840),
	25.7,
	0,
	Cast('1/1/2016' AS DATETIME),
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
    SET @newDbVersion = '0.49'
    BEGIN
        EXEC AppendDbVersionInfo @newDbVersion, 'OS-306 Added more currency rates'
        
        PRINT 'Completed successfully'
    END
END
GO
-- End writing new version info