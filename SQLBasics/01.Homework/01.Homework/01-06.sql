/* Problem 1. Create Database */
/* Problem 2. Create Tables */
/* Problem 3. Alter Minions Table */
/* Problem 4. Insert Records in Both Tables */


CREATE TABLE Minions (
[Id] INT PRIMARY KEY,
[Name] NVARCHAR(30), 
[Age] INT
)

CREATE TABLE Towns (
[Id] INT PRIMARY KEY,
[Name] NVARCHAR(30)
)

ALTER TABLE Minions
ADD TownId INT FOREIGN KEY REFERENCES Towns(Id)


INSERT INTO Towns ([Id],[Name]) VALUES
('1','Sofia'),
('2','Plovdiv'),
('3','Varna')

INSERT INTO Minions ([Id],[Name],[Age],[TownId]) VALUES
('1','Kevin' , '22', '1'),
('2','Bob' , '15', '3')

INSERT INTO Minions ([Id],[Name],[TownId]) VALUES
('3','Steward' ,  '2')

GO

SELECT * FROM Minions
SELECT * FROM Towns

/* Problem 5. Truncate Table Minions */

TRUNCATE TABLE Towns
