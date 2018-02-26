USE Bakery
GO

SELECT CONCAT(C.FirstName, ' ', C.LastName) AS CustomerName,
	   C.PhoneNumber,
	   C.Gender
FROM Customers AS C
WHERE C.Id NOT IN (SELECT F.CustomerId FROM Feedbacks AS F GROUP BY CustomerId)
ORDER BY C.Id ASC