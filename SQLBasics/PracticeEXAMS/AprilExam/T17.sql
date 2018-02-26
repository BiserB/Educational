USE WMS
GO
CREATE FUNCTION udf_GetCost(@JobId INT)
RETURNS DECIMAL(15,2) 
AS
BEGIN
RETURN(
	SELECT ISNULL(SUM(P.Price * OP.Quantity),0)
	FROM Orders AS O
	JOIN OrderParts AS OP
	ON OP.OrderId = O.OrderId
	JOIN Parts AS P
	ON P.PartId = OP.PartId
	WHERE O.JobId = @JobId)
END
GO

SELECT dbo.udf_GetCost (100)