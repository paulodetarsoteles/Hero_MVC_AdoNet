USE [db_Hero_MVC_AdoNet]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[HeroInsert]
	@Name VARCHAR(50),
	@Active BIT,
	@UpdateDate DATETIME
AS
BEGIN
	INSERT INTO Heroes
		([Name], [Active], [UpdateDate])
	VALUES
		(@Name, @Active, @UpdateDate)
	OPTION (MAXDOP 2)
	SELECT CAST(SCOPE_IDENTITY() AS INT)
END
