--Criação da tabela de identidades secretas
CREATE TABLE Secrets (
	SecretId INT PRIMARY KEY NOT NULL, 
	[Name] VARCHAR(50) NOT NULL, 
	HeroId INT FOREIGN KEY REFERENCES Heroes(HeroId) NULL)