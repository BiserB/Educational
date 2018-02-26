
USE ReportService
GO

SELECT C.Name AS CategoryName,
	   COUNT(R.Id) AS ReportsNumber
FROM Categories AS C
JOIN Reports AS R
ON R.CategoryId = C.Id
GROUP BY C.Name
ORDER BY ReportsNumber DESC, CategoryName 