﻿USE [db_Hero_MVC_AdoNet]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SecretDelete]
	@SecretId INT
AS
BEGIN
	DELETE Secrets 
	WHERE SecretId = @SecretId
	OPTION (MAXDOP 2)
END