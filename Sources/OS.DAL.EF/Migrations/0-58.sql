 -- Start checking possibility of using
 DECLARE @newDbVersion       VARCHAR(11)
 SET @newDbVersion = '0.58'
 
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

WHILE (1 = 1)
BEGIN
    DECLARE @tableIndexes TABLE(
                Id INT,
                DESCRIPTION NVARCHAR(4000),
                [INDEX] INT,
                OrderNumber INT,
                PhotoId INT NULL,
                NewDescription NTEXT NULL
            )
    
    DECLARE @wrongUrl NVARCHAR(1000) = 'http://allvent.com.ua/productphotos/'
    
    INSERT INTO @tableIndexes
    SELECT *,
           ROW_NUMBER() OVER(ORDER BY T.Id),
           NULL,
           NULL
    FROM   (
               SELECT Id,
                      DESCRIPTION,
                      CHARINDEX(@wrongUrl, DESCRIPTION) AS 'Index'
               FROM   Products
               WHERE  LEN(DESCRIPTION) < 4000
           ) T
    WHERE  T.[Index] IS NOT NULL
           AND T.[Index] <> 0
    
    DECLARE @rowIndex INT = 1;
    DECLARE @totalRowsCount INT = (
                SELECT COUNT(*)
                FROM   @tableIndexes
            )
    
    WHILE @rowIndex < @totalRowsCount + 1
    BEGIN
        DECLARE @index           INT = (
                    SELECT TOP 1 [Index]
                    FROM   @tableIndexes
                    WHERE  OrderNumber = @rowIndex
                ) + 36
        
        DECLARE @description     NVARCHAR(4000) = (
                    SELECT TOP 1 [Description]
                    FROM   @tableIndexes
                    WHERE  OrderNumber = @rowIndex
                )
        
        DECLARE @result VARCHAR(8) = ''
        DECLARE @pos INT = @index
        WHILE ISNUMERIC(SUBSTRING(@description, @pos, 1)) = 1
        BEGIN
            SET @result = @result + SUBSTRING(@description, @pos, 1)
            SET @pos = @pos + 1
        END
        
        UPDATE @tableIndexes
        SET    PhotoId = CAST(@result AS INT)
        WHERE  OrderNumber = @rowIndex
        
        
        
        SET @rowIndex = @rowIndex + 1
    END
    
    UPDATE @tableIndexes
    SET    [NewDescription] = REPLACE(
               [Description],
               @wrongUrl + CONVERT(VARCHAR(10), PhotoId),
               'http://allvent.com.ua/api/photos/' + CONVERT(VARCHAR(10), PhotoId) + '/whatermarked'
           )
    
    UPDATE Products
    SET    [Description] = (
               SELECT [NewDescription]
               FROM   @tableIndexes T
               WHERE  T.Id = Products.Id
           )
    WHERE  Products.Id IN (SELECT Id
                           FROM   @tableIndexes)
    
    IF (
           SELECT COUNT(*)
           FROM   @tableIndexes
       ) = 0
        BREAK
    
    DELETE FROM @tableIndexes
END


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
     SET @newDbVersion = '0.58'
     BEGIN
         EXEC AppendDbVersionInfo @newDbVersion, 'OS-365 Early added images to the products are not visible for now'
         
         PRINT 'Completed successfully'
     END
 END
 GO
 -- End writing new version info