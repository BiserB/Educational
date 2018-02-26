
SELECT D.Name AS DistributorName,
	   I.Name AS IngredientName,
	   P.Name AS ProductName,
	   AVG(F.Rate) AS AverageRate	   
FROM Products AS P
JOIN ProductsIngredients AS PRI
ON PRI.ProductId = P.Id
JOIN Ingredients AS I
ON I.Id = PRI.IngredientId
JOIN Distributors AS D
ON D.Id = I.DistributorId
JOIN Feedbacks AS F
ON F.ProductId = P.Id
GROUP BY D.Name,I.Name,P.Name
HAVING AVG(F.Rate) BETWEEN 5 AND 8
ORDER BY D.Name, I.Name, P.Name

