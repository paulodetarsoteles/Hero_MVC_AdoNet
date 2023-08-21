--Criação da tabela de relação entre heróis e filmes
CREATE TABLE HeroesMovies (
	HeroMovieId INT PRIMARY KEY NOT NULL, 
	HeroId INT FOREIGN KEY REFERENCES Heroes(HeroId), 
	MovieId INT FOREIGN KEY REFERENCES Movies(MovieId))