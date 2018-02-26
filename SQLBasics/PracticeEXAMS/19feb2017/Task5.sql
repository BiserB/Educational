SELECT P.Name,
	   P.Price,
	   P.Description
FROM Products AS P
ORDER BY Price DESC, Name ASC
