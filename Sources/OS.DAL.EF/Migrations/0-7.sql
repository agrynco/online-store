-- Start checking possibility of using
DECLARE @newDbVersion       VARCHAR(11)
SET @newDbVersion = '0.7'

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

INSERT INTO ProductCategories
(
	-- Id -- this column value is auto-generated
	[Description],
	Name,
	ParentId
)
VALUES
(
	N'Организации, деятельность которых связана с установкой и техническим обслуживанием воздуховодов приобретают вентиляционный хомут оптом. Этот распространенный крепеж используется для быстрого и удобного монтажа элементов вентиляционных систем и воздуховодов. Вентиляционный хомут купить также могут индивидуальные клиенты для местного ремонта или крепления воздуховодов в домашних условиях.',
	N'Вентиляционный хомут',
	7
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
    SET @newDbVersion = '0.7'
    BEGIN
        EXEC AppendDbVersionInfo @newDbVersion, ''
        
        PRINT 'Completed successfully'
    END
END
GO
-- End writing new version info