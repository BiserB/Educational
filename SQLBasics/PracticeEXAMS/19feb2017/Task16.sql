USE Bakery
GO

CREATE VIEW v_UserWithCountries
AS
SELECT CONCAT(C.FirstName, ' ',C.LastName) AS CustomerName,
	  C.Age,
	  C.Gender,
	  Co.Name AS CountryName
FROM Customers AS C
JOIN Countries AS Co
ON Co.Id = C.CountryId