USE ReportService
GO
SELECT C.Name AS CategoryName,
	   COUNT(E.Id) AS [Employees Number]
  FROM Categories AS C
  JOIN Departments AS D
    ON D.Id = C.DepartmentId
  JOIN Employees AS E
    ON E.DepartmentId = D.Id
GROUP BY C.Name
ORDER BY C.Name
