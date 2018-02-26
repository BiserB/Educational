USE ReportService
GO

SELECT FS.Name, 
	   CONCAT(FS.Closed,'/',FS.Opened) AS [Closed Open Reports]
FROM
(
SELECT CONCAT(E.FirstName,' ',E.LastName) AS [Name],
	   E.Id,
	   ISNULL((SELECT COUNT(R.Id)
				 FROM Reports AS R
				WHERE DATEPART(YEAR,CloseDate) = '2016' 
				  AND R.EmployeeId = E.Id                  
             GROUP BY EmployeeId),0) as Closed,
			 
	    ISNULL((SELECT COUNT(R.Id)
				 FROM Reports AS R
				WHERE DATEPART(YEAR,OpenDate) = '2016' 
				AND R.EmployeeId = E.Id                  
             GROUP BY EmployeeId),0)  AS Opened
FROM Employees AS E
JOIN Reports AS R
ON R.EmployeeId = E.Id
) AS FS
WHERE FS.opened >=1

group by FS.Name, FS.Id, CONCAT(FS.Closed,'/',FS.Opened)
ORDER BY FS.Name, FS.Id



SELECT COUNT(R.Id)
  FROM Reports AS R
 WHERE DATEPART(YEAR,OpenDate) = 2016
   GROUP BY EmployeeId


SELECT ISNULL(NULL,0)