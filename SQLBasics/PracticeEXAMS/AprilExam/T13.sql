




 SELECT J.JobId,
	    (SELECT ISNULL(SUM(OP.Quantity *  P.Price),0) 
   FROM Jobs AS Jo
    JOIN Orders AS O
      ON O.JobId = Jo.JobId
    JOIN OrderParts AS OP
      ON OP.OrderId = O.OrderId
    JOIN Parts AS P
      ON P.PartId = OP.PartId
   WHERE Jo.JobId = J.JobId) AS Total
   FROM Jobs AS J
WHERE J.Status = 'Finished'
ORDER BY Total DESC, JobId