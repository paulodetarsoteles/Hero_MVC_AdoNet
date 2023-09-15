USE [db_Hero_MVC_AdoNet]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetHeroesByMovieId]
	@MovieId INT
AS
BEGIN
	SELECT h.[HeroId], h.[Name], h.[Active], h.[UpdateDate]  
	FROM HeroesMovies hm 
		INNER JOIN Heroes h ON h.HeroId = hm.HeroId
	WHERE hm.MovieId = @MovieId
	ORDER BY 1 DESC
END