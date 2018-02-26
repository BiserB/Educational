CREATE DATABASE Homework
USE Homework
GO
---------------------------------------1
CREATE TABLE Persons (
PersonID INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(30),
Salary DECIMAL (10,2),
PassportID INT
)
CREATE TABLE Passports(
PassportID INT PRIMARY KEY,
PassportNumber NVARCHAR(30)
)

INSERT INTO Persons(FirstName,Salary,PassportID) VALUES
('Roberto',43300.00,102),
('Tom'  ,  56100.00,103),
('Yana' ,  60200.00,101)

INSERT INTO Passports VALUES
(101,'N34FG21B'),
(102,'K65LO4R7'),
(103,'ZE657QP2')


ALTER TABLE Persons
ADD CONSTRAINT FK_Passports_PassportID FOREIGN KEY (PassportID) REFERENCES Passports(PassportID)


select FirstName, Salary FROM  Persons

---------------------------------------2

CREATE TABLE Models (
[ModelID] INT PRIMARY KEY IDENTITY(101,1), 
[Name] NVARCHAR(30),
[ManufacturerID] INT
)
CREATE TABLE Manufacturers(
[ManufacturerID] INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(30),
[EstablishedOn] DATE
)
ALTER TABLE Models
ADD CONSTRAINT FK_Manufacturers_ManufacturerID 
FOREIGN KEY ([ManufacturerID]) REFERENCES Manufacturers(ManufacturerID)

INSERT INTO Manufacturers([Name],[EstablishedOn]) VALUES
('BMW', '07/03/1916'),
('Tesla', '01/01/2003'),
('Lada', '01/05/1966')

INSERT INTO Models([Name],[ManufacturerID]) VALUES
('X1',1),
('i6',1),
('Model S',2),
('Model X',2),
('Model 3',2),
('Nova',3)

SELECT [Models].[Name],[Manufacturers].[Name]
FROM Models JOIN Manufacturers
ON Models.ManufacturerID = Manufacturers.ManufacturerID

EXEC sp_columns Models

-------------------------------------------------3

CREATE TABLE Students(
StudentID INT,
[Name] NVARCHAR(30),
PRIMARY KEY(StudentID)
)
CREATE TABLE Exams(
ExamID INT,
[Name]NVARCHAR(30),
PRIMARY KEY(ExamID)
)
CREATE TABLE StudentExams(
StudentID INT,
ExamID INT,
PRIMARY KEY(StudentID, ExamID),
FOREIGN KEY ([StudentID]) REFERENCES Students([StudentID]),
FOREIGN KEY (ExamID) REFERENCES Exams(ExamID)
)
INSERT INTO Students VALUES
(1,'Mila'),
(2,'Toni'),
(3,'Ron')

INSERT INTO Exams VALUES
(101,'SpringMVC'),
(102,'Neo4j'),
(103,'Oracle 11g')

INSERT INTO StudentExams VALUES
(1,'101'),
(1,'102'),
(2,'101'),
(3,'103'),
(2,'102'),
(2,'103')

select * from StudentExams

---------------------------------------------------------4
CREATE TABLE Teachers(
[TeacherID] INT NOT NULL,
[Name] NVARCHAR(30) NOT NULL,
[ManagerID] INT,
PRIMARY KEY ([TeacherID]),
FOREIGN KEY ([ManagerID]) REFERENCES Teachers([TeacherID])
)
INSERT INTO Teachers ([TeacherID],[Name],[ManagerID]) VALUES
(101,'John',NULL),
(102,'Maya',106),
(103,'Silvia',106),
(104,'Ted',105),
(105,'Mark',101),
(106,'Greta',101)

EXEC sp_columns Teachers

-----------------------------------------------5
DROP DATABASE OnlineStore
USE master

USE OnlineStore
GO

CREATE DATABASE OnlineStore

USE OnlineStore
GO

CREATE TABLE Cities (
[CityID] INT,
[Name] VARCHAR(50) NOT NULL,
PRIMARY KEY ([CityID])
)
CREATE TABLE Customers (
[CustomerID] INT ,
[Name] VARCHAR(50) NOT NULL,
[Birthday] DATE,
[CityID] INT NOT NULL,
PRIMARY KEY ([CustomerID]),
FOREIGN KEY ([CityID]) REFERENCES Cities([CityID])
)
CREATE TABLE Orders(
[OrderID] INT,
[CustomerID] INT NOT NULL,
PRIMARY KEY (OrderID),
FOREIGN KEY (CustomerID) REFERENCES Customers([CustomerID])
)

CREATE TABLE ItemTypes(
[ItemTypeID] INT PRIMARY KEY,
[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Items(
ItemID INT PRIMARY KEY,
[Name] VARCHAR(50) NOT NULL,
[ItemTypeID] INT NOT NULL
FOREIGN KEY ([ItemTypeID]) REFERENCES ItemTypes([ItemTypeID])
)

CREATE TABLE OrderItems(
OrderID INT,
ItemID INT,
PRIMARY KEY (OrderID, ItemID),
FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
FOREIGN KEY (ItemID) REFERENCES Items(ItemID)
)

----------------------------------------------- 6
CREATE DATABASE University
USE University
GO
CREATE TABLE Majors(
[MajorID] INT PRIMARY KEY,
[Name] NVARCHAR(30) NOT NULL
)
CREATE TABLE Students(
[StudentID] INT PRIMARY KEY,
[StudentNumber] INT NOT NULL,
[StudentName] NVARCHAR(30) NOT NULL,
[MajorID] INT FOREIGN KEY REFERENCES Majors([MajorID])
)
CREATE TABLE Payments(
PaymentID INT PRIMARY KEY,
PaymentDate DATE,
PaymentAmmount DECIMAL(15,2),
StudentID INT FOREIGN KEY REFERENCES Students(StudentID)
)
CREATE TABLE Subjects(
SubjectID INT PRIMARY KEY,
SubjectName NVARCHAR(30) NOT NULL
)
CREATE TABLE Agenda(
[StudentID] INT,
[SubjectID] INT,
PRIMARY KEY([StudentID],[SubjectID]), 
FOREIGN KEY ([StudentID]) REFERENCES Students([StudentID]),
FOREIGN KEY ([SubjectID]) REFERENCES Subjects([SubjectID])
)


---------------------------------------------9

USE Geography
GO
select * from INFORMATION_SCHEMA.TABLES

SELECT * FROM Mountains
SELECT * FROM Peaks


SELECT Mountains.MountainRange, 
		Peaks.[PeakName], 
		Peaks.[Elevation] AS PeakElevation
FROM Peaks JOIN Mountains ON MountainId = Mountains.Id
WHERE MountainRange = 'Rila'
ORDER BY PeakElevation DESC


----------------------------------------- test

USE Homework
GO
CREATE TABLE Test(
TestID INT,
[Notes] NVARCHAR
)
INSERT INTO Test VALUES
(1,'A'),
(2,'B'),
(3,'C')