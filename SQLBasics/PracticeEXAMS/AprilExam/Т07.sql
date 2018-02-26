
USE WMS
GO
SELECT CONCAT(M.FirstName, ' ',M.LastName) AS Mechanic,
	   J.Status,
	   J.IssueDate
FROM Mechanics AS M
JOIN Jobs AS J
ON (J.MechanicId = m.MechanicId)
ORDER BY M.MechanicId, J.IssueDate, J.JobId

--mechanic Id, issue date, job Id