


SELECT P.PartId,
	   P.Description,
	   PN.Quantity AS [Required],
	   P.StockQty AS [In Stock],
	   O.Delivered 
FROM Jobs AS J
JOIN PartsNeeded AS PN
ON PN.JobId = J.JobId
JOIN Parts AS P
ON P.PartId = PN.PartId
JOIN OrderParts AS OP
ON OP.PartId = P.PartId
JOIN Orders AS O
ON O.OrderId = OP.OrderId
WHERE J.Status != 'Finished' AND PN.Quantity > (P.StockQty + O.Delivered)


----------------------

GO

WITH WorstModel (ModelId,Faults) AS
(SELECT J.ModelId,
		COUNT(J.ModelId) AS Faults
FROM Jobs AS J
GROUP BY J.ModelId
ORDER BY Faults DESC) 

