USE Bakery
GO

SELECT TOP 1 WITH TIES Co.Name AS CountryName,
					   AVG(F.Rate) AS FeedbackRate
FROM Feedbacks AS F
JOIN Customers AS C
ON C.Id = F.CustomerId
JOIN Countries AS Co
ON Co.Id = c.CountryId
GROUP BY Co.Name
ORDER BY FeedbackRate DESC
