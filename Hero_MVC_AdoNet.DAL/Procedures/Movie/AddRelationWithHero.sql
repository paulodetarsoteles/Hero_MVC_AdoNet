USE [db_Hero_MVC_AdoNet]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddRelationWithHero]
	@HeroId INT,
	@MovieId INT
AS
BEGIN
	INSERT INTO HeroesMovies 
		(HeroId, MovieId)
	VALUES
		(@HeroId, @MovieId)
END