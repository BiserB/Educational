USE ReportService
GO

SELECT C.Name AS [Category Name]
FROM Categories AS C
WHERE C.Id IN (SELECT R.CategoryId
				 FROM Reports AS R
                 JOIN Users AS U
                   ON U.Id = R.UserId
                WHERE DATEPART(MONTH,R.OpenDate) = DATEPART(MONTH,U.BirthDate)
                  AND DATEPART(DAY,R.OpenDate) = DATEPART(DAY,U.BirthDate))
ORDER BY [Category Name]

