USE Bakery
GO
SELECT F.ProductId,
	   CONCAT(C.FirstName,' ',C.LastName) AS CustomerName,
	   F.Description
	FROM Customers AS C
	JOIN Feedbacks AS F
	ON F.CustomerId = C.Id
	WHERE C.Id IN (SELECT F.CustomerId	   	
FROM Feedbacks AS F
GROUP BY F.CustomerId
HAVING COUNT(F.Id) >=3)
ORDER BY F.ProductId, CustomerName, F.Id




