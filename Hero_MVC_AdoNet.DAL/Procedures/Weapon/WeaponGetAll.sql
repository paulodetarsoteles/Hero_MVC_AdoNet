﻿USE db_Hero_MVC_AdoNet
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE WeaponGetAll 
AS
BEGIN
	SELECT TOP 1000 *  
		FROM Weapons
	ORDER BY 1 DESC 
	OPTION (MAXDOP 2)
END
GO