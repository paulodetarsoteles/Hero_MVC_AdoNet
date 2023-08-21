--Criação da tabela de armas
CREATE TABLE Weapons (
	WeaponId INT PRIMARY KEY NOT NULL, 
	[Name] VARCHAR(50) NOT NULL, 
	[Type] INT NOT NULL,
	HeroId INT FOREIGN KEY REFERENCES Heroes(HeroId) NULL)