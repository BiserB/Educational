SELECT A.AddressText,
	   T.Name,
	   COUNT(E.EmployeeID) AS qty
		FROM Addresses AS A
		JOIN Towns AS T
		ON T.TownID = A.TownID
		JOIN Employees AS E
		ON E.AddressID = A.AddressID
		GROUP BY A.AddressText, T.Name
		ORDER BY qty DESC