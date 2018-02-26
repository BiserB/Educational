USE WMS
GO
--CONCAT(M.FirstName, ' ', M.LastName) AS Mechanic

SELECT CONCAT(M.FirstName, ' ', M.LastName) AS Mechanic,
AVG(DATEDIFF(DAY,J.IssueDate,J.FinishDate)) AS [Average Days]
FROM Mechanics AS M
JOIN Jobs AS J
ON (J.MechanicId = M.MechanicId)
GROUP BY M.MechanicId, CONCAT(M.FirstName, ' ', M.LastName)
ORDER BY M.MechanicId
