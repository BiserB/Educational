USE WMS
GO
SELECT TOP 1 WITH TIES	   
	   M.Name,
	   COUNT(J.JobId) AS [Times Serviced],
	   (SELECT ISNULL(SUM(OP.Quantity * P.Price),0)
		  FROM Jobs AS Jo
          JOIN Orders AS O
            ON O.JobId = Jo.JobId
          JOIN OrderParts AS OP
            ON OP.OrderId = O.OrderId
          JOIN Parts AS P
            ON P.PartId = OP.PartId
         WHERE Jo.ModelId = J.ModelId) AS [Parts Total]
FROM Jobs AS J
JOIN Models AS M
ON M.ModelId = J.ModelId
GROUP BY M.Name, J.ModelId
ORDER BY [Times Serviced] DESC


------------------------------------

SELECT SUM(OP.Quantity * P.Price)
FROM Jobs AS Jo
JOIN Orders AS O
ON O.JobId = Jo.JobId
JOIN OrderParts AS OP
ON OP.OrderId = O.OrderId
JOIN Parts AS P
ON P.PartId = OP.PartId
WHERE Jo.ModelId = 2
