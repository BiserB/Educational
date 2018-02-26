USE ReportService
GO
SELECT E.FirstName, 
	   E.LastName, 
	   R.Description, 
	   FORMAT(R.OpenDate, 'yyyy-MM-dd') AS OpenDate
FROM Employees AS E
JOIN Reports AS R
ON R.EmployeeId = E.Id
ORDER BY E.Id, R.OpenDate, R.Id