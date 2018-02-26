USE Bakery
GO

SELECT F.ProductId,
	   CONCAT(C.FirstName,' ',C.LastName) AS CustomerName,
	   F.Description
FROM Feedbacks AS F
JOIN Customers AS C
ON C.Id = F.CustomerId
WHERE F.CustomerId IN (SELECT CustomerId  FROM Feedbacks GROUP BY CustomerId HAVING COUNT(CustomerId) >=3)
ORDER BY F.ProductId ASC, CustomerName ASC, F.Id ASC
/*GROUP BY F.CustomerId, F.ProductId,C.FirstName,F.Description