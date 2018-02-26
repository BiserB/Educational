

SELECT CONCAT(M.FirstName, ' ', M.LastName) AS Mechanic,
	   COUNT(*) AS Jobs
FROM Mechanics AS M
JOIN Jobs AS J
ON (J.MechanicId = M.MechanicId)
WHERE J.Status != 'Finished'
GROUP BY CONCAT(M.FirstName, ' ', M.LastName), M.MechanicId
HAVING COUNT(J.JobId) > 1
ORDER BY Jobs DESC, M.MechanicId