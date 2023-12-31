﻿USE [db_Hero_MVC_AdoNet]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SecretUpdate]
	@SecretId INT,
	@Name VARCHAR(50),
	@HeroId INT = NULL
AS
BEGIN
	UPDATE Secrets 
	SET 
		Name = @Name,
		HeroId = @HeroId
	WHERE SecretId = @SecretId
	OPTION (MAXDOP 2)
END