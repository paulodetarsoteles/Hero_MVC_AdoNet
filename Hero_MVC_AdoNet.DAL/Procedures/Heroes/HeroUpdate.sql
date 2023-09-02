USE [db_Hero_MVC_AdoNet]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[HeroUpdate]
	@HeroId INT,
	@Name VARCHAR(50),
	@Active BIT,
	@UpdateDate DATETIME
AS
BEGIN
	UPDATE Heroes 
	SET 
		Name = @Name, 
		Active = @Active,
		UpdateDate = @UpdateDate 
	WHERE HeroId = @HeroId
	OPTION (MAXDOP 2)
END