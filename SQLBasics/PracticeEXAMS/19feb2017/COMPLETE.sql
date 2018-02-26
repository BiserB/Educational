--01. DDL
CREATE TABLE Countries
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) UNIQUE
)

CREATE TABLE Customers
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(25),
	LastName NVARCHAR(25),
	Gender CHAR CHECK(Gender IN ('M', 'F')),
	Age INT,
	PhoneNumber CHAR(10),
	CountryId INT FOREIGN KEY REFERENCES Countries(Id)
)

CREATE TABLE Distributors
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(25) UNIQUE,
	AddressText NVARCHAR(30),
	Summary NVARCHAR(200),
	CountryId INT FOREIGN KEY REFERENCES Countries(Id)
)

CREATE TABLE Ingredients
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30),
	[Description] NVARCHAR(200),
	OriginCountryId INT FOREIGN KEY REFERENCES Countries(Id),
	DistributorId INT FOREIGN KEY REFERENCES Distributors(Id)
)

CREATE TABLE Products
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(25) UNIQUE,
	[Description] NVARCHAR(250),
	Recipe NVARCHAR(MAX),
	Price MONEY CHECK(Price > 0)
)

CREATE TABLE Feedbacks
(
	Id INT PRIMARY KEY IDENTITY,
	[Description] NVARCHAR(255),
	Rate DECIMAL(4, 2) CHECK(Rate BETWEEN 0 AND 10),
	ProductId INT FOREIGN KEY REFERENCES Products(Id),
	CustomerId INT FOREIGN KEY REFERENCES Customers(Id)
)

CREATE TABLE ProductsIngredients
(
	ProductId INT FOREIGN KEY REFERENCES Products(Id),
	IngredientId INT FOREIGN KEY REFERENCES Ingredients(Id),
	CONSTRAINT PK_ProductsIngredients PRIMARY KEY(ProductId, IngredientId)
)

--02. Insert
INSERT INTO Distributors ([Name], CountryId, AddressText, Summary) VALUES
('Deloitte & Touche', 2, '6 Arch St #9757', 'Customizable neutral traveling'),
('Congress Title', 13, '58 Hancock St', 'Customer loyalty'),
('Kitchen People', 1, '3 E 31st St #77', 'Triple-buffered stable delivery'),
('General Color Co Inc', 21, '6185 Bohn St #72', 'Focus group'),
('Beck Corporation', 23, '21 E 64th Ave', 'Quality-focused 4th generation hardware')

INSERT INTO Customers (FirstName, LastName, Age, Gender, PhoneNumber, CountryId) VALUES
('Francoise', 'Rautenstrauch', 15, 'M', '0195698399', 5),
('Kendra', 'Loud', 22, 'F', '0063631526', 11),
('Lourdes', 'Bauswell', 50, 'M', '0139037043', 8),
('Hannah', 'Edmison', 18, 'F', '0043343686', 1),
('Tom', 'Loeza', 31, 'M', '0144876096', 23),
('Queenie', 'Kramarczyk', 30, 'F', '0064215793', 29),
('Hiu', 'Portaro', 25, 'M', '0068277755', 16),
('Josefa', 'Opitz', 43, 'F', '0197887645', 17)

--03. Update
UPDATE Ingredients
SET DistributorId = 35
WHERE [Name] IN ('Bay Leaf', 'Paprika', 'Poppy')

UPDATE Ingredients
SET OriginCountryId = 14
WHERE OriginCountryId = 8

--04. Delete
DELETE FROM Feedbacks
WHERE CustomerId = 14 OR ProductId = 5

--05. Products By Price
SELECT [Name], Price, [Description]
FROM Products
ORDER BY Price DESC, [Name] ASC

--06. Ingredients
SELECT [Name], [Description], OriginCountryId
FROM Ingredients
WHERE OriginCountryId IN (1, 10, 20)
ORDER BY Id

--07. Ingredients from Bulgaria and Greece
SELECT TOP 15 i.[Name], i.[Description], c.[Name] AS CountryName
FROM Ingredients AS i
INNER JOIN Countries AS c ON i.OriginCountryId = c.Id
WHERE OriginCountryId IN (SELECT Id FROM Countries WHERE [Name] IN ('Bulgaria', 'Greece'))
ORDER BY i.[Name], CountryName

--08. Best Rated Products
SELECT TOP(10) p.[Name], p.[Description], AVG(f.Rate) AS AverageRate, COUNT(f.Id) AS FeedbacksAmount
FROM Products AS p
JOIN Feedbacks AS f ON p.Id = f.ProductId
GROUP BY p.[Name], p.[Description]
ORDER BY AverageRate DESC, FeedbacksAmount DESC

--09. Negative Feedback
SELECT f.ProductId, f.Rate, f.[Description], f.CustomerId, c.Age, c.Gender
FROM Feedbacks AS f
JOIN Customers AS c ON f.CustomerId = c.Id
WHERE f.Rate < 5.0
ORDER BY ProductId DESC, Rate ASC

--10. Customers without Feedback
--With Subquery
SELECT CONCAT(FirstName, ' ', LastName) AS [Name], PhoneNumber, Gender
FROM Customers
WHERE Id NOT IN (SELECT CustomerId FROM Feedbacks)

--With Outer Join
SELECT CONCAT(FirstName, ' ', LastName) AS [Name], PhoneNumber, Gender
FROM Customers AS c
LEFT OUTER JOIN Feedbacks AS f ON c.Id = f.CustomerId
WHERE f.Id IS NULL

--11. Honorable Mentions
SELECT ProductId, CONCAT(c.FirstName, ' ', c.LastName) AS CustomerName, f.[Description]
FROM Feedbacks AS f
JOIN Customers AS c ON f.CustomerId = c.Id
WHERE c.Id IN (
	SELECT CustomerId
	FROM Feedbacks AS f
	GROUP BY CustomerId
	HAVING COUNT(f.Id) >= 3
)
ORDER BY ProductId, CustomerName, f.Id

--12. Customers by Criteria
SELECT FirstName, Age, PhoneNumber
FROM Customers
WHERE Age >= 21 AND FirstName LIKE '%an%' OR
	RIGHT(PhoneNumber, 2) = '38' AND CountryId <> (SELECT Id FROM Countries WHERE [Name] = 'Greece')
ORDER BY FirstName, Age DESC

--13. Middle Range Distributors
SELECT d.[Name] AS DistributorName,
	i.[Name] AS IngredientName, 
	p.[Name] AS ProductName, 
	AVG(Rate) AS AverageRate
FROM Distributors AS d
JOIN Ingredients AS i ON d.Id = i.DistributorId
JOIN ProductsIngredients AS pii ON i.Id = pii.IngredientId
JOIN Products AS p ON pii.ProductId = p.Id
JOIN Feedbacks AS f ON p.Id = f.ProductId
GROUP BY d.[Name], i.[Name], p.[Name]
HAVING AVG(Rate) BETWEEn 5 AND 8
ORDER BY DistributorName, IngredientName, ProductName

--14. The Most Positive Country
SELECT TOP(1) WITH TIES
	c.[Name] AS CountryName, AVG(f.Rate) AS FeedbackRate
FROM Countries AS c
JOIN Customers AS cc ON c.Id = cc.CountryId
JOIN Feedbacks AS f ON cc.Id = f.CustomerId
GROUP BY c.[Name]
ORDER BY FeedbackRate DESC

--15. Country Representative
SELECT CountryName, DistributorName
FROM (
	SELECT c.[Name] AS CountryName, d.[Name] AS DistributorName, 
		COUNT(i.Id) AS IngredientCount, 
		DENSE_RANK() OVER(PARTITION BY c.[Name] ORDER BY COUNT(i.Id) DESC) AS [Rank]
	FROM Countries AS c
	JOIN Distributors AS d ON d.CountryId = c.Id
	LEFT JOIN Ingredients AS i ON d.Id = i.DistributorId
	GROUP BY c.[Name], d.[Name]
) AS RankedDistributors
WHERE [Rank] = 1
ORDER BY CountryName, DistributorName

--16. Customers With Countries
CREATE VIEW v_UserWithCountries AS
SELECT CONCAT(FirstName, ' ', LastName) AS CustomerName,
	Age, Gender, co.[Name] AS CountryName
FROM Customers AS c
JOIN Countries AS co ON c.CountryId = co.Id

--17. Feedback by Product Name
CREATE FUNCTION udf_GetRating (@name NVARCHAR(30))
RETURNS VARCHAR(10) AS
BEGIN
	DECLARE @avgRate DECIMAL(4, 2) = (SELECT AVG(Rate) FROM Products AS p
										JOIN Feedbacks AS f ON p.Id = f.ProductId
										WHERE [Name] = @name)
	DECLARE @rating VARCHAR(10) =
		CASE WHEN @avgRate IS NULL THEN 'No rating'
		WHEN @avgRate < 5.00 THEN 'Bad'
		WHEN @avgRate <= 8.00 THEN 'Average'
		ELSE 'Good' END
	RETURN @rating
END

--18. Send Feedback
CREATE PROC usp_SendFeedback @customerId INT, @productId INT, @rate DECIMAL(4, 2),
	@description NVARCHAR(255) AS
BEGIN
BEGIN TRANSACTION
	INSERT INTO Feedbacks (CustomerId, ProductId, Rate, [Description]) VALUES
	(@customerId, @productId, @rate, @description)
	DECLARE @feedbackCount INT = (
		SELECT COUNT(f.Id)
		FROM Feedbacks AS f
		WHERE ProductId = @productId AND CustomerId = @customerId)
	IF @feedbackCount > 3
	BEGIN
		ROLLBACK
		RAISERROR('You are limited to only 3 feedbacks per product!', 16, 1)		
	END
	ELSE
		COMMIT
END

--19. Delete Products
CREATE TRIGGER t_DeleteProduct ON Products INSTEAD OF DELETE
AS
BEGIN
	DECLARE @productId INT = (SELECT Id FROM deleted)

	DELETE FROM Feedbacks
	WHERE ProductId = @productId

	DELETE FROM ProductsIngredients
	WHERE ProductId = @productId

	DELETE FROM Products
	WHERE Id = @productId
END

--20. Products by One Distributor
WITH CTE AS (
	SELECT p.Id AS ProductId,
		p.[Name] AS ProductName, 
		AVG(f.Rate) AS AverageRate,
		d.[Name] AS DistributorName,
		c.[Name] AS DistributorCountry 
	FROM Products AS p
	JOIN Feedbacks AS f ON p.Id = f.ProductId
	JOIN ProductsIngredients AS pii ON p.Id = pii.ProductId
	JOIN Ingredients AS i ON pii.IngredientId = i.Id
	JOIN Distributors AS d ON i.DistributorId = d.Id
	JOIN Countries AS c ON c.Id = d.CountryId
	GROUP BY p.[Name], d.[Name], c.[Name], p.Id)

SELECT CTE.ProductName, AverageRate, DistributorName, DistributorCountry
FROM CTE
JOIN (
	SELECT ProductName, COUNT(DistributorName) AS DistributorCount
	FROM CTE
	GROUP BY ProductName
) AS DistributorCount ON CTE.ProductName = DistributorCount.ProductName
WHERE DistributorCount = 1
ORDER BY ProductId