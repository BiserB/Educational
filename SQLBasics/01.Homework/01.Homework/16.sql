CREATE DATABASE Hotel
GO
USE Hotel
CREATE TABLE Employees (
Id INT PRIMARY KEY IDENTITY, 
FirstName NVARCHAR(30) NOT NULL, 
LastName NVARCHAR(30) NOT NULL, 
Title NVARCHAR(30) NOT NULL, 
Notes NVARCHAR(MAX)
)
CREATE TABLE Customers (
AccountNumber INT PRIMARY KEY IDENTITY, 
FirstName NVARCHAR(30) NOT NULL, 
LastName NVARCHAR(30) NOT NULL, 
PhoneNumber NVARCHAR(30), 
EmergencyName NVARCHAR(30), 
EmergencyNumber NVARCHAR(30), 
Notes NVARCHAR(MAX)
)
CREATE TABLE RoomStatus (
RoomStatus NVARCHAR(30) PRIMARY KEY NOT NULL, 
Notes NVARCHAR(MAX)
)
CREATE TABLE RoomTypes (
RoomType NVARCHAR(30)PRIMARY KEY NOT NULL,
Notes NVARCHAR(MAX)
)
CREATE TABLE BedTypes (
BedType NVARCHAR(30)PRIMARY KEY NOT NULL,
Notes NVARCHAR(MAX)
)
CREATE TABLE Rooms (
RoomNumber INT PRIMARY KEY,
RoomType NVARCHAR(30) FOREIGN KEY REFERENCES RoomTypes(RoomType) NOT NULL, 
BedType NVARCHAR(30) FOREIGN KEY REFERENCES BedTypeS(BedType) NOT NULL, 
Rate INT, 
RoomStatus NVARCHAR(30) FOREIGN KEY REFERENCES RoomStatus(RoomStatus), 
Notes NVARCHAR(MAX)
 )
 CREATE TABLE Payments (
 Id INT PRIMARY KEY, 
 EmployeeId INT, 
 PaymentDate DATE, 
 AccountNumber NVARCHAR(30) NOT NULL, 
 FirstDateOccupied DATE, 
 LastDateOccupied DATE, 
 TotalDays INT NOT NULL, 
 AmountCharged INT NOT NULL, 
 TaxRate DECIMAL(2,2), 
 TaxAmount DECIMAL(15,2), 
 PaymentTotal DECIMAL(15,2) NOT NULL, 
 Notes NVARCHAR(MAX)
 )
 CREATE TABLE Occupancies (
 Id INT PRIMARY KEY, 
 EmployeeId INT, 
 DateOccupied DATE, 
 AccountNumber NVARCHAR(30), 
 RoomNumber INT NOT NULL, 
 RateApplied DECIMAL, 
 PhoneCharge DECIMAL, 
 Notes NVARCHAR(30)
 )

 INSERT INTO Employees(FirstName, LastName, Title) VALUES
 ('Sponge', 'Bob', 'employee'),
 ('Mister', 'Sepia', 'cashier'),
 ('Mister', 'Crab', 'boss')

 INSERT INTO Customers(FirstName, LastName) VALUES
 ('Pesho','Peshev'),
 ('Ivan','Ivanov'),
 ('Bob','Bobchev')
 INSERT INTO RoomStatus(RoomStatus) VALUES
 ('Free'),
 ('Occupied'),
 ('Renovation')
 INSERT INTO RoomTypes(RoomType) VALUES
 ('STANDART'),
 ('ECONOMIC'),
 ('LUXURY')

 INSERT INTO BedTypes(BedType) VALUES
 ('SINGLE'),
 ('DOUBLE'),
 ('SMALL-DOUBLE')
 INSERT INTO Rooms(RoomNumber, RoomType, BedType, RoomStatus) VALUES
 ('111', 'STANDART', 'SINGLE', 'Free'),
 ('222', 'STANDART', 'SINGLE', 'Free'),
 ('333', 'STANDART', 'SINGLE', 'Free')
 INSERT INTO Payments(Id, AccountNumber, TotalDays, AmountCharged, PaymentTotal, PaymentDate) VALUES
 ('1','98765','3','30','36','05-05-2005'),
 ('2','12345','2','20','24','05-09-2005'),
 ('3','66666','1','10','12','05-12-2005')
 INSERT INTO Occupancies(Id, RoomNumber) VALUES
 (1, 111),
 (2, 222),
 (3, 333)

 UPDATE Payments
 SET TaxRate *= 0.97
 SELECT TaxRate FROM Payments

 TRUNCATE TABLE Occupancies