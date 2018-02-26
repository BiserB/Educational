USE ReportService
GO

WITH AverageTime (Name, [Average Duration])
AS
(SELECT D.Name, 
	   CAST(AVG(DATEDIFF(DAY,R.OpenDate, R.CloseDate))AS varchar)AS [Average Duration]
FROM Departments AS D
JOIN Categories AS C
ON C.DepartmentId = D.Id
JOIN Reports AS R
ON R.CategoryId = C.Id
GROUP BY D.Name
)

SELECT A.Name,
	   [Average Duration] = (CASE 
							 WHEN A.[Average Duration] IS NULL THEN 'no info'
							 ELSE A.[Average Duration]
							 END)
FROM AverageTime AS A

