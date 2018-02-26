USE ReportService
GO

   SELECT CONCAT(E.FirstName,' ',E.LastName) AS Name,
	      COUNT( R.UserId) AS [Users Number]
     FROM Employees AS E
LEFT JOIN Reports AS R
       ON R.EmployeeId = E.Id
 GROUP BY  CONCAT(E.FirstName,' ',E.LastName)
 ORDER BY [Users Number] DESC, Name


