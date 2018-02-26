USE Bakery
GO

SELECT TOP 1 WITH TIES
	   C.Name AS CountryName,
	   AVG(F.Rate) AS FeedbackRate
FROM Countries AS C
JOIN Customers AS CU
ON CU.CountryId = C.Id
JOIN Feedbacks AS F
ON F.CustomerId = CU.Id
GROUP BY C.Name
ORDER BY FeedbackRate DESC