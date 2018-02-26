USE Bakery
GO

SELECT C.FirstName,
	   C.Age,
	   C.PhoneNumber
FROM Customers AS C
WHERE C.Age >= 21 AND (C.FirstName LIKE('%an%')OR C.PhoneNumber LIKE '%38')
				  AND C.CountryId != 31
ORDER BY C.FirstName ASC, C.Age DESC 

GO
SELECT * FROM Countries
WHERE Name = 'Greece'