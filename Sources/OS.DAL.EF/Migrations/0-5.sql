-- Start checking possibility of using
DECLARE @newDbVersion       VARCHAR(11)
SET @newDbVersion = '0.5'

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
INSERT INTO [DevOnlineStore].[dbo].[AspNetUsers]
  (
    [Id],
    [Email],
    [EmailConfirmed],
    [PasswordHash],
    [SecurityStamp],
    [PhoneNumber],
    [PhoneNumberConfirmed],
    [TwoFactorEnabled],
    [LockoutEndDateUtc],
    [LockoutEnabled],
    [AccessFailedCount],
    [UserName]
  )
VALUES
  (
    '5babe839-9bf0-49b5-be57-a4d2bccb1148',
    'test.adm.onlinestore@gmail.com',
    0,
    'ABZoTbT3t70RYR4DoHUEM9gCpDftK+LhMAsnvsctunVquGe4WUbMvQzCz+xpzKr9pg==',
    'c27fe5b4-a058-44b4-959a-1b0b2c6367e9',
    NULL,
    0,
    0,
    NULL,
    0,
    0,
    'test.adm.onlinestore@gmail.com'
  );

INSERT INTO AspNetRoles
(
	Id,
	Name
)
VALUES
(
	'921CBB1F-40FC-40BB-8D31-485015D07A7C',
	'admin'
)

INSERT INTO AspNetUserRoles
(
	UserId,
	RoleId
)
VALUES
(
	'5babe839-9bf0-49b5-be57-a4d2bccb1148',
	'921CBB1F-40FC-40BB-8D31-485015D07A7C'
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
    SET @newDbVersion = '0.5'
    BEGIN
        EXEC AppendDbVersionInfo @newDbVersion, 'Add admin role and user with this role'
        
        PRINT 'Completed successfully'
    END
END
GO
-- End writing new version info