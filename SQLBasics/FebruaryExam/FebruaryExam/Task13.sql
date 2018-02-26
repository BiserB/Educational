USE Bakery
GO

SELECT D.Name AS DistributorName,
	   I.Name AS IngredientName,
	   P.Name AS ProductName,
	   AVG(F.Rate) AS AverageRate
FROM Distributors AS D
JOIN Ingredients AS I
ON I.DistributorId = D.Id
JOIN ProductsIngredients AS PRI
ON PRI.IngredientId = I.Id
JOIN Products AS P
ON P.Id = PRI.ProductId
JOIN Feedbacks AS F
ON F.ProductId = P.Id
GROUP BY D.Name, I.Name, P.Name
HAVING (AVG(F.Rate) >= 5 AND AVG(F.Rate) <= 8)
ORDER BY D.Name, I.Name, P.Name
