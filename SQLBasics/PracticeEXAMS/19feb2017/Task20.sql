
USE Bakery
GO
--------------------------WHERE
SELECT P.Name
FROM Products AS P
JOIN ProductsIngredients AS PRI
ON PRI.ProductId = P.Id
JOIN Ingredients AS I
ON I.Id = PRI.IngredientId
GROUP BY P.Name
HAVING COUNT(I.DistributorId) = 1
-----------------------------------
GO
WITH NameRating (ProductName,ProductAverageRate)
AS
(  SELECT  
          ISNULL(AVG(F.Rate),0 )
     FROM Products
LEFT JOIN Feedbacks AS F
       ON F.ProductId = Products.Id
 GROUP BY Products.Name
 HAVING Products.Name =  P.Name)


SELECT  P.Name AS ProductName,
		AVG(F.Rate) AS AverageRate,
		D.Name AS DistributorName,
	    C.Name AS DistributorCountry 		
           FROM Products AS P
           JOIN ProductsIngredients AS PR
		   ON PR.ProductId = P.Id
		   JOIN Ingredients AS I
		   ON I.Id = PR.IngredientId
		   JOIN Distributors AS D
		   ON D.Id = I.DistributorId
		   JOIN Countries AS C
		   ON C.Id = D.CountryId
		   JOIN Feedbacks AS F
		   ON F.ProductId = P.Id
		GROUP BY P.Name, D.Name, C.Name, P.Id    
	 HAVING COUNT(I.DistributorId) = 1
			ORDER BY P.Id
			  
