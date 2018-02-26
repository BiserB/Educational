USE WMS
GO

SELECT CONCAT(C.FirstName, ' ', C.LastName) AS Client,
	   DATEDIFF(DAY,J.IssueDate, '2017-04-24') AS [Days going],
	   J.Status
FROM Clients AS C
JOIN Jobs AS J
ON (J.ClientId  = C.ClientId)
WHERE J.Status != 'Finished'
ORDER BY [Days going] DESC, C.ClientId
