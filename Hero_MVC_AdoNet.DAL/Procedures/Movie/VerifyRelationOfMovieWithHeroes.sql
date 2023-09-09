USE [db_Hero_MVC_AdoNet]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[VerifyRelationOfMovieWithHeroes]
	@MovieId INT
AS
BEGIN
	SELECT COUNT(HeroMovieId) 
	FROM HeroesMovies 
	WHERE MovieId = @MovieId
END