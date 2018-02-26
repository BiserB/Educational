USE WMS
GO

SELECT CONCAT(M.FirstName,' ',M.LastName) AS Available
  FROM Mechanics AS M
  WHERE M.MechanicId NOT IN (SELECT MechanicId 
							   FROM Jobs
                              WHERE [Status] != 'Finished' AND MechanicId IS NOT NULL
                           GROUP BY MechanicId)
ORDER BY M.MechanicId



