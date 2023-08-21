--Criação da tabela heróis
CREATE TABLE Heroes (
	HeroId INT PRIMARY KEY NOT NULL, 
	[Name] VARCHAR(50) NOT NULL, 
	Active BIT NOT NULL,
	UpdateDate DateTime NOT NULL)