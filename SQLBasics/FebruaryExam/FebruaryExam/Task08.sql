use Bakery
GO

SELECT TOP 10
	   P.Name,
	   P.Description,
	   AVG(F.Rate) AS AverageRate,
	   Count(F.Id) AS FeedbacksAmount
FROM Products AS P
JOIN Feedbacks AS F
ON F.ProductId = P.Id
GROUP BY P.Name, P.Description
ORDER BY AverageRate DESC, FeedbacksAmount DESC


GO
SELECT * FROM Feedbacks
ORDER BY ProductId