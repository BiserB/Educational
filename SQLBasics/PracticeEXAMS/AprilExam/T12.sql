USE WMS
GO

SELECT ISNULL(SUM(P.Price * OP.Quantity),0) AS [Parts Total Cost]
FROM Parts AS P
JOIN OrderParts AS OP
ON (OP.PartId = P.PartId)
JOIN Orders AS O
ON (O.OrderId = OP.OrderId)
WHERE DATEDIFF(WEEK,O.IssueDate, '2017-04-24') <= 3 