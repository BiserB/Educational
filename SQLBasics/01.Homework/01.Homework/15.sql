CREATE DATABASE CarRental

CREATE TABLE Categories(
Id INT PRIMARY KEY IDENTITY, 
CategoryName NVARCHAR(30) NOT NULL, 
DailyRate DECIMAL(15,2) NOT NULL, 
WeeklyRate DECIMAL(15,2) NOT NULL, 
MonthlyRate DECIMAL(15,2) NOT NULL, 
WeekendRate DECIMAL(15,2) NOT NULL
)
CREATE TABLE Cars (
Id INT PRIMARY KEY IDENTITY, 
PlateNumber NVARCHAR(10) NOT NULL,
Manufacturer NVARCHAR(30) NOT NULL, 
Model NVARCHAR(30) NOT NULL, 
CarYear INT, 
CategoryId INT NOT NULL, 
Doors INT, 
Picture VARBINARY, 
Condition NVARCHAR(30), 
Available BIT NOT NULL
)
CREATE TABLE Employees (
Id INT PRIMARY KEY IDENTITY, 
FirstName NVARCHAR(30), 
LastName NVARCHAR(30), 
Title NVARCHAR(30), 
Notes NVARCHAR(MAX)
)

CREATE TABLE Customers (
Id INT PRIMARY KEY IDENTITY, 
DriverLicenceNumber INT NOT NULL, 
FullName NVARCHAR(60) NOT NULL, 
[Address] NVARCHAR(30), 
City NVARCHAR(30), 
ZIPCode INT, 
Notes NVARCHAR(MAX)
)

CREATE TABLE RentalOrders (
Id INT PRIMARY KEY IDENTITY, 
EmployeeId INT  NOT NULL, 
CustomerId INT  NOT NULL, 
CarId INT  NOT NULL, 
TankLevel DECIMAL(1,1), 
KilometrageStart INT, 
KilometrageEnd INT, 
TotalKilometrage INT, 
StartDate DATE, 
EndDate DATE, 
TotalDays INT, 
RateApplied INT NOT NULL, 
TaxRate INT NOT NULL, 
OrderStatus INT, 
Notes NVARCHAR(MAX)
)

INSERT INTO Categories ([CategoryName],[DailyRate],[WeeklyRate], MonthlyRate, WeekendRate) VALUES
('economic', 5, 12, 30, 10),
('standart', 7, 15, 40, 20),
('luxury', 10, 24, 60, 25)

INSERT INTO Cars (PlateNumber, Manufacturer, Model, CategoryId, Available) VALUES
('CC12342BB', 'Ford', 'Ka', 1, 1),
('CC12355BB', 'Ford', 'Focus', 2, 1),
('CC12366BB', 'Ford', 'Mondeo', 3, 1)

INSERT INTO Customers (DriverLicenceNumber, FullName) VALUES
('123456','Sponge Bob'),
('654321','Al ALEXOV'),
('652344','Alex ALEXOV')

INSERT INTO Employees (FirstName, LastName) VALUES
('Bob','Sponge'),
('Big','Bang'),
('Saturn','ALEXOV')

INSERT INTO RentalOrders (EmployeeId,CustomerId,CarId,RateApplied,TaxRate ) VALUES
('1', '1', '3', 10, 20),
('2', '1', '3', 20, 40),
('3', '1', '3', 40, 60)

SELECT * FROM Cars
SELECT * FROM Customers
SELECT * FROM Employees
SELECT * FROM RentalOrders