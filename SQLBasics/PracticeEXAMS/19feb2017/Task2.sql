CREATE DATABASE Ins
USE Ins
GO
CREATE TABLE Distributors(
[Id] INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(50),
[CountryId] INT CHECK(CountryId > 0),
[AddressText] NVARCHAR(50),
[Summary] NVARCHAR(255)
)
CREATE TABLE Customers(
[Id] INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(30),
LastName NVARCHAR(30),
Age INT CHECK(Age > 0),
Gender CHAR(1) CHECK (Gender = 'M' or Gender = 'F'),
PhoneNumber CHAR(10),
CountryId INT CHECK(CountryId > 0)
)


USE Bakery
GO
INSERT INTO Distributors([Name],CountryId,AddressText,Summary) VALUES
('Deloitte & Touche',2,'6 Arch St #9757','Customizable neutral traveling'),
('Congress Title',13,'58 Hancock St','Customer loyalty'),
('Kitchen People',1,'3 E 31st St #77','Triple-buffered stable delivery'),
('General Color Co Inc',21,'6185 Bohn St #72','Focus group'),
('Beck Corporation',23,'21 E 64th Ave','Quality-focused 4th generation hardware')

INSERT INTO Customers (FirstName,LastName,Age,Gender,PhoneNumber,CountryId) VALUES
('Francoise','Rautenstrauch',15,'M','0195698399',5),
('Kendra','Loud',22,'F','0063631526',11),
('Lourdes','Bauswell',50,'M','0139037043',8),
('Hannah','Edmison',18,'F','0043343686',1),
('Tom','Loeza',31,'M','0144876096',23),
('Queenie','Kramarczyk',30,'F','0064215793',29),
('Hiu','Portaro',25,'M','0068277755',16),
('Josefa','Opitz',43,'F','0197887645',17)