USE [db_Hero_MVC_AdoNet]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[WeaponUpdate]
	@WeaponId INT,
	@Name VARCHAR(50),
	@Type INT = 1,
	@HeroId INT = NULL
AS
BEGIN
	UPDATE Weapons 
	SET 
		Name = @Name,
		Type = @Type,
		HeroId = @HeroId
	WHERE WeaponId = @WeaponId
	OPTION (MAXDOP 2)
END