USE [master]
GO
/****** Object:  Database [{DB_NAME}]    Script Date: 30.08.2015 20:12:31 ******/
CREATE DATABASE [{DB_NAME}]
GO
USE [{DB_NAME}]
GO
/****** Object:  StoredProcedure [dbo].[AppendDbVersionInfo]    Script Date: 30.08.2015 20:12:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AppendDbVersionInfo]
	@dbVersion VARCHAR(11),
	@notes NVARCHAR(255)
AS
	INSERT INTO DbVersions
	  (
		Major,
		Minor,
		Notes
	  )
	VALUES
	  (
		dbo.ParseMajorDbVersion(@dbVersion),
		dbo.ParseMinorDbVersion(@dbVersion),
		@notes
	  )
GO
/****** Object:  UserDefinedFunction [dbo].[CheckVersioningIntegrity]    Script Date: 30.08.2015 20:12:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[CheckVersioningIntegrity]
(
)
RETURNS INT
AS
BEGIN
	IF OBJECT_ID('dbo.DbVersions', 'table') IS NULL
	BEGIN
		RETURN 1;
	END
	
	IF OBJECT_ID('dbo.GetCurrentDbVersionAsString', 'function') IS NULL
	BEGIN
		RETURN 2;
	END
	
	IF OBJECT_ID('dbo.ParseMajorDbVersion', 'function') IS NULL
	BEGIN
		RETURN 3;
	END
	
	IF OBJECT_ID('dbo.ParseMinorDbVersion', 'function') IS NULL
	BEGIN
		RETURN 4;
	END;
	
	IF OBJECT_ID('dbo.AppendDbVersionInfo', 'procedure') IS NULL
	BEGIN
		RETURN 5;
	END;
	
	IF OBJECT_ID('dbo.CompareDbVersions', 'function') IS NULL
	BEGIN
		RETURN 6;
	END;
	
	IF OBJECT_ID('dbo.CompareDbVersionWithCurrent', 'function') IS NULL
	BEGIN
		RETURN 7;
	END;
	
	IF OBJECT_ID('dbo.CurrentDbVersion', 'view') IS NULL
	BEGIN
		RETURN 8;
	END;
	
	RETURN 0;
END

GO
/****** Object:  UserDefinedFunction [dbo].[CompareDbVersions]    Script Date: 30.08.2015 20:12:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- RETURNS 
-- -1 IF @x < @y 
--  0 IF @x = @y
--  1 IF @x > @y
-- -2 IF (@xMajor = @yMajor AND @xMinor > @yMinor AND (@xMinor - @yMinor) <> 1
CREATE FUNCTION [dbo].[CompareDbVersions]
(
	@x     VARCHAR(11),
	@y     VARCHAR(11)
)
RETURNS INT
AS
BEGIN
	DECLARE @xMajor INT
	DECLARE @xMinor INT
	
	DECLARE @yMajor INT
	DECLARE @yMinor INT
	
	SET @xMajor = dbo.ParseMajorDbVersion(@x)
	SET @xMinor = dbo.ParseMinorDbVersion(@x)
	
	SET @yMajor = dbo.ParseMajorDbVersion(@y)
	SET @yMinor = dbo.ParseMinorDbVersion(@y)
	
	DECLARE @result INT
	SET @result = -2
	
	IF (
		   @xMajor < @yMajor
		   OR (@xMajor = @yMajor AND @xMinor < @yMinor)
	   )
		SET @result = -1
	ELSE 
	IF (
		   @xMajor > @yMajor
		   OR (@xMajor = @yMajor AND @xMinor > @yMinor AND (@xMinor - @yMinor) = 1)
	   )
		SET @result = 1
	
	RETURN @result
END

GO
/****** Object:  UserDefinedFunction [dbo].[CompareDbVersionWithCurrent]    Script Date: 30.08.2015 20:12:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[CompareDbVersionWithCurrent]
(
	@dbVersion VARCHAR(11)
)
RETURNS INT
AS
BEGIN
	DECLARE @currentDbVersion VARCHAR(11)
	SET @currentDbVersion = dbo.GetCurrentDbVersionAsString()
	
	RETURN dbo.CompareDbVersions(@dbVersion, @currentDbVersion)
END

GO
/****** Object:  UserDefinedFunction [dbo].[GetCurrentDbVersionAsString]    Script Date: 30.08.2015 20:12:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- End checking possibility of using

-- BEGIN CHANGES

CREATE FUNCTION [dbo].[GetCurrentDbVersionAsString]
(
)
RETURNS VARCHAR(11)
AS
BEGIN
	DECLARE @result NVARCHAR(10)

	IF EXISTS (
		   SELECT TOP 1 * 
		   FROM   DbVersions
		   ORDER BY Major, Minor DESC
	   )
	BEGIN
		SET @result = (
				SELECT TOP 1
					   CAST(Major AS VARCHAR(5)) + '.' + CAST(Minor AS VARCHAR(5))
				FROM   DbVersions
				ORDER BY Major DESC, Minor DESC
			)
	END
	ELSE
	BEGIN
		SET @result = '0.0'
	END
	RETURN @result

END

GO
/****** Object:  UserDefinedFunction [dbo].[ParseMajorDbVersion]    Script Date: 30.08.2015 20:12:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[ParseMajorDbVersion]
(
	@strDbVersion VARCHAR(11)
)
RETURNS INT
AS
BEGIN
	DECLARE @splitData TABLE (Id INT, Item VARCHAR(5))
	INSERT INTO @splitData
	SELECT *
	FROM   dbo.SplitString(@strDbVersion, '.')
	
	DECLARE @result INT
	
	DECLARE @majorDbVersionAsString VARCHAR(5)
	
	SET @majorDbVersionAsString = (
			SELECT TOP 1
				   item
			FROM   @splitData
			WHERE  Id = 0
		)  
	
	SET @result = TRY_PARSE(@majorDbVersionAsString AS INT)
	
	RETURN @result
END

GO
/****** Object:  UserDefinedFunction [dbo].[ParseMinorDbVersion]    Script Date: 30.08.2015 20:12:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[ParseMinorDbVersion]
(
	@strDbVersion VARCHAR(11)
)
RETURNS INT
AS
BEGIN
	DECLARE @splitData TABLE (Id INT, Item VARCHAR(5))
	INSERT INTO @splitData
	SELECT *
	FROM   dbo.SplitString(@strDbVersion, '.')
	
	DECLARE @result INT
	
	DECLARE @majorDbVersionAsString VARCHAR(5)
	
	SET @majorDbVersionAsString = (
			SELECT TOP 1
				   item
			FROM   @splitData
			WHERE  Id = 1
		) 
	
	SET @result = TRY_PARSE(@majorDbVersionAsString AS INT)
	
	RETURN @result
END

GO
/****** Object:  Table [dbo].[DbVersions]    Script Date: 30.08.2015 20:12:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DbVersions](
	[Major] [int] NOT NULL,
	[Minor] [int] NOT NULL,
	[AppliedAt] [datetime2](7) NOT NULL,
	[Notes] [nvarchar](255) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  UserDefinedFunction [dbo].[SplitString]    Script Date: 30.08.2015 20:12:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[SplitString]
(
	@str           NVARCHAR(MAX),
	@separator     CHAR(1)
)
RETURNS TABLE
AS
	RETURN 
	(
		WITH tokens(p, a, b) AS 
			 (
				 SELECT CAST(1 AS BIGINT),
						CAST(1 AS BIGINT),
						CHARINDEX(@separator, @str)
				 UNION ALL
				 SELECT p + 1,
						b + 1,
						CHARINDEX(@separator, @str, b + 1)
				 FROM   tokens
				 WHERE  b > 0
			 )
	
	SELECT p - 1 AS ItemIndex,
		   LTRIM(RTRIM(SUBSTRING(@str, a, IIF(b > 0, b - a, LEN(@str))))) AS 
		   Item
	FROM   tokens
	);

GO
/****** Object:  View [dbo].[CurrentDbVersion]    Script Date: 30.08.2015 20:12:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[CurrentDbVersion] AS
SELECT dbo.ParseMajorDbVersion(dbo.GetCurrentDbVersionAsString()) AS 
	   MajorVersion,
	   dbo.ParseMinorDbVersion(dbo.GetCurrentDbVersionAsString()) AS 
	   MinorVersion

GO
ALTER TABLE [dbo].[DbVersions] ADD  DEFAULT (getdate()) FOR [AppliedAt]
GO
USE [master]
GO
ALTER DATABASE [{DB_NAME}] SET  READ_WRITE 
GO
