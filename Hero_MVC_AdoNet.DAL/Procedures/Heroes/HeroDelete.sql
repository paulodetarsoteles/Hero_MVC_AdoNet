﻿USE [db_Hero_MVC_AdoNet]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[HeroDelete]
	@HeroId INT
AS
BEGIN
	DELETE Heroes 
	WHERE HeroId = @HeroId
	OPTION (MAXDOP 2)
END