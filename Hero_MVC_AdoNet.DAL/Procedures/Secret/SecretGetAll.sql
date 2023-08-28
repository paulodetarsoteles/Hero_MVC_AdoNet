﻿USE [db_Hero_MVC_AdoNet]
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SecretGetAll] 
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * 
		FROM Secrets
	ORDER BY 1 DESC 
	OPTION (MAXDOP 2)
END
