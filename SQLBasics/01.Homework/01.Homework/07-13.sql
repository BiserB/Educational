/* Problem 7. Create Table People */

USE Minions
CREATE TABLE People(
[Id] INT PRIMARY KEY,
[Name] NVARCHAR(200) NOT NULL,
[Picture] VARBINARY(MAX) CHECK (Picture < 2000000),
[Height] FLOAT(2),
[Weight] FLOAT(2),
[Gender] VARCHAR(1) CHECK(Gender in ('f', 'm')) NOT NULL,
[Birthdate] DATE NOT NULL,
[Biography] NVARCHAR(MAX)
)
INSERT INTO People([Id],[Name], [Gender], [Birthdate]) VALUES
('1','Ivan', 'm', '1977-05-05'),
('2','Alex', 'm', '1977-05-04'),
('3','Pesho', 'm', '1977-05-03'),
('4','Gosho', 'm', '1977-05-02'),
('5','Bob', 'm', '1977-05-01')

SELECT * FROM People

/* Problem 8. Create Table Users */

USE Minions
CREATE TABLE Users(
[Id] BIGINT PRIMARY KEY IDENTITY,
[Username] VARCHAR(30) NOT NULL,
[Password] VARCHAR(26) NOT NULL,
[ProfilePicture] BINARY(900),
[LastLoginTime] DATE,
[IsDeleted] BIT
)
INSERT INTO Users ( [Username], [Password]) VALUES
( 'Pesho', 'pass'),
( 'Alex', 'passt'),
( 'Bate', 'passtt'),
( 'Pate', 'passttt'),
( 'Vanka', 'passttt')
Select * FROM Users

/* Problem 10. Add Check Constraint */

ALTER TABLE Users
ADD CONSTRAINT Pass_Length CHECK([Password.] > 5)

/* Problem 13. Movies Database */

CREATE DATABASE Movies

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

USE Minions

SELECT * FROM   sys.objects
WHERE type_desc LIKE '%CONSTRAINT' AND OBJECT_NAME(parent_object_id)='Users'

ALTER TABLE Users
DROP CONSTRAINT PK__Users__3214EC07FDB36209

ALTER TABLE Users
ADD PRIMARY KEY (Id, Username)