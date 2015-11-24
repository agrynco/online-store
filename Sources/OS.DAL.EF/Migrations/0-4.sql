-- Start checking possibility of using
DECLARE @newDbVersion       VARCHAR(11)
SET @newDbVersion = '0.4'

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

INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'078cfc62-9bdd-43fb-ba90-3278c8b539fb', N'dev.onlinestore@gmail.com', 0, N'AAzl24XBLNuxQX25kNeFCBIzTq0jTkmkrPeptgeuQK4p+YI1qOTbd95VhYMyBO9RDA==', N'33616428-ba0e-4a05-830a-4d921ea6316d', NULL, 0, 0, NULL, 0, 0, N'dev.onlinestore@gmail.com')

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
    SET @newDbVersion = '0.4'
    BEGIN
        EXEC AppendDbVersionInfo @newDbVersion, 'Add test account'
        
        PRINT 'Completed successfully'
    END
END
GO
-- End writing new version info