USE ReportService
GO

SELECT R.Description,
	   R.OpenDate
FROM Reports AS R
WHERE R.EmployeeId IS NULL
ORDER BY R.OpenDate, R.Description