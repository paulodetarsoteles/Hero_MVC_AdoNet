﻿USE [db_Hero_MVC_AdoNet]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[VerifyRelationWithSecret]
	@HeroId INT
AS
BEGIN
	SELECT COUNT(SecretId) 
	FROM Secrets 
	WHERE HeroId = @HeroId
END