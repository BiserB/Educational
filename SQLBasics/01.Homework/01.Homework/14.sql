/*  Problem 14. Car Rental Database */

CREATE DATABASE Movies

USE Movies

CREATE TABLE Directors(
Id INT PRIMARY KEY IDENTITY,
DirectorName NVARCHAR(30) NOT NULL,
Notes NVARCHAR(MAX)
)
CREATE TABLE Genres(
Id INT PRIMARY KEY IDENTITY,
GenreName NVARCHAR(30) NOT NULL,
Notes NVARCHAR(MAX)
)
CREATE TABLE Categories(
Id INT PRIMARY KEY IDENTITY,
CategoryName NVARCHAR(30) NOT NULL,
Notes NVARCHAR(MAX)
)
CREATE TABLE Movies(
Id INT PRIMARY KEY IDENTITY,
Title NVARCHAR(30) NOT NULL,
DirectorId INT,
CopyrightYear INT,
[Length] DECIMAL(2),
GenreId INT,
CategoryId INT,
Rating DECIMAL(1,1),
Notes NVARCHAR(MAX)
)

INSERT INTO Directors (DirectorName) VALUES
('Copola'),
('Tarantino'),
('Scott'),
('Pesho'),
('Gosho')

INSERT INTO Genres (GenreName) VALUES
('Action'),
('Romance'),
('Comedy'),
('Pesho'),
('Gosho')

INSERT INTO Categories(CategoryName) VALUES
('Action'),
('Romance'),
('Comedy'),
('Pesho'),
('Gosho')

INSERT INTO Movies (Title,CopyrightYear) VALUES
('Gladiator', 2001),
('Kill Bill', 2007),
('Godfather', 188),
('Pesho', 2010),
('Gosho', 2009)

SELECT * FROM dbo.Movies
