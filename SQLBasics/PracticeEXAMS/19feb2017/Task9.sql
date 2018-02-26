USE Bakery
GO
SELECT F.ProductId,
	   F.Rate,
	   F.Description,
	   F.CustomerId,
	   C.Age,
	   C.Gender
FROM Feedbacks AS F
JOIN Customers AS C
ON (C.Id = F.CustomerId)
WHERE F.Rate < 5.0
ORDER BY F.ProductId DESC, F.Rate

