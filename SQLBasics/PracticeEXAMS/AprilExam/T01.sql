CREATE DATABASE WMS
GO
USE WMS
GO

--Clients
CREATE TABLE Clients(
ClientId INT PRIMARY KEY IDENTITY NOT NULL,
FirstName VARCHAR(50) NOT NULL,
LastName VARCHAR(50) NOT NULL,
Phone CHAR(12) NOT NULL
)

--Mechanics
CREATE TABLE Mechanics(
MechanicId INT PRIMARY KEY IDENTITY NOT NULL,
FirstName VARCHAR(50) NOT NULL,
LastName VARCHAR(50) NOT NULL,
Address VARCHAR(255) NOT NULL
)

--Models
CREATE TABLE Models(
ModelId INT PRIMARY KEY IDENTITY NOT NULL,
Name VARCHAR(50) UNIQUE NOT NULL
)

--Vendors
CREATE TABLE Vendors(
VendorId INT PRIMARY KEY IDENTITY NOT NULL,
Name VARCHAR(50) UNIQUE NOT NULL
)

--Jobs
CREATE TABLE Jobs(
JobId INT PRIMARY KEY IDENTITY NOT NULL,
ModelId INT FOREIGN KEY REFERENCES Models(ModelId) NOT NULL,
[Status] NVARCHAR(11) CHECK ([Status] IN ('Pending','In Progress','Finished')) DEFAULT 'Pending',
ClientId INT FOREIGN KEY REFERENCES Clients(ClientId) NOT NULL,
MechanicId INT FOREIGN KEY REFERENCES Mechanics(MechanicId),
IssueDate DATE NOT NULL,
FinishDate DATE
)

--Orders
CREATE TABLE Orders(
OrderId INT PRIMARY KEY IDENTITY NOT NULL,
JobId INT FOREIGN KEY REFERENCES Jobs(JobId) NOT NULL,
IssueDate DATE,
Delivered BIT DEFAULT 0
)

--Parts
CREATE TABLE Parts(
PartId INT PRIMARY KEY IDENTITY NOT NULL,
SerialNumber VARCHAR(50) UNIQUE NOT NULL,
Description VARCHAR(255),
Price DECIMAL(6,2) CHECK (Price > 0) NOT NULL,
VendorId INT FOREIGN KEY REFERENCES Vendors(VendorId) NOT NULL,
StockQty INT CHECK (StockQty >= 0) DEFAULT 0
)


--PartsNeeded
CREATE TABLE PartsNeeded(
JobId INT FOREIGN KEY REFERENCES Jobs(JobId) NOT NULL,
PartId INT FOREIGN KEY REFERENCES Parts(PartId) NOT NULL,
Quantity INT CHECK (Quantity > 0) DEFAULT 1,
CONSTRAINT PK_PartsNeeded PRIMARY KEY (JobId, PartId)
)


--OrderParts
CREATE TABLE OrderParts(
OrderId INT FOREIGN KEY REFERENCES Orders([OrderId]) NOT NULL,
PartId INT FOREIGN KEY REFERENCES Parts(PartId) NOT NULL,
Quantity INT CHECK (Quantity > 0) DEFAULT 1,
CONSTRAINT PK_OrderParts PRIMARY KEY (OrderId, PartId)
)
