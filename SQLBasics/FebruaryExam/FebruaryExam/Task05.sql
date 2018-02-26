USE Bakery
GO

SELECT P.Name,
	   P.Price,
	   P.Description
FROM Products AS P
ORDER BY P.Price DESC, P.Name ASC
