USE [db_Hero_MVC_AdoNet]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MovieUpdate]
	@MovieId INT,
	@Name VARCHAR(50),
	@Rate INT
AS
BEGIN
	UPDATE Movies 
	SET 
		Name = @Name, 
		Rate = @Rate
	WHERE MovieId = @MovieId
	OPTION (MAXDOP 2)
END