-- Start checking possibility of using
DECLARE @newDbVersion VARCHAR(11);

SET @newDbVersion = '0.2';

DECLARE @currentDbVersion VARCHAR(11);

SET @currentDbVersion = dbo.GetCurrentDbVersionAsString();

DECLARE @errorMessage NVARCHAR(500);

IF dbo.CompareDbVersionWithCurrent( @newDbVersion ) <> 1
    BEGIN
        SET @errorMessage = 'Cannot install script ' + @newDbVersion + '. DB version ' + @currentDbVersion + ' expected.';
        RAISERROR( @errorMessage, 20, -1 ) WITH LOG;
    END;
GO

-- End checking possibility of using
-- BEGIN CHANGES
DELETE FROM ProductCategories;

INSERT INTO ProductCategories( [Description], NAME, Parent_Id )
VALUES( NULL, N'Решетки, Дифузоры', NULL );

INSERT INTO ProductCategories( [Description], NAME, Parent_Id )
VALUES( NULL, N'Дверки', NULL );

INSERT INTO ProductCategories( [Description], NAME, Parent_Id )
VALUES( NULL, N'Фасонина (монтажные елементы)', NULL );

INSERT INTO ProductCategories( [Description], NAME, Parent_Id )
VALUES( NULL, N'Вентиляторы', NULL );

INSERT INTO ProductCategories( [Description], NAME, Parent_Id )
VALUES( NULL, N'Воздуховоды', NULL );

INSERT INTO ProductCategories( [Description], NAME, Parent_Id )
VALUES( NULL, N'Электроуправляющие устройства', NULL );

INSERT INTO ProductCategories( [Description], NAME, Parent_Id )
VALUES( NULL, N'Крепеж', NULL );

INSERT INTO ProductCategories( [Description], NAME, Parent_Id )
VALUES( NULL, N'Изоляция', NULL );

INSERT INTO ProductCategories( [Description], NAME, Parent_Id )
VALUES( NULL, N'Приточно-вытяжные установки', NULL );

INSERT INTO ProductCategories( [Description], NAME, Parent_Id )
VALUES( NULL, N'Прочее', NULL );

INSERT INTO ProductCategories( [Description], NAME, Parent_Id )
VALUES( NULL, N'Зонты', NULL );
-- END CHANGES
-- Start writing new version info 
GO

IF @@ERROR <> 0
    BEGIN
        DECLARE @errorMessage VARCHAR(MAX);
        SET @errorMessage = ERROR_MESSAGE();
        RAISERROR( @errorMessage, 16, 1 );
    END;
ELSE
    BEGIN
        DECLARE @newDbVersion VARCHAR(11);
        SET @newDbVersion = '0.2';
        BEGIN
            EXEC AppendDbVersionInfo @newDbVersion, '';
            PRINT 'Completed successfully';
        END;
    END;
GO
-- End writing new version info