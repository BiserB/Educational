USE ReportService
GO

WITH cteTotal(Name,total)
AS
(SELECT  D.Name AS Name,
		 COUNT(R.Id)  AS number
    FROM Departments AS D
    JOIN Categories AS C
      ON C.DepartmentId = D.Id
    JOIN Reports AS R
      ON R.CategoryId = C.Id	
GROUP BY D.Name)


  SELECT D.Name AS [Department Name], 
	     C.Name AS [Category Name], 
	     CAST(ROUND(COUNT(R.Id) * 100.0 / T.total,0)AS INT)   AS Percentage		 
    FROM Departments AS D
    JOIN Categories AS C
      ON C.DepartmentId = D.Id
    JOIN Reports AS R
      ON R.CategoryId = C.Id
	JOIN cteTotal AS T
	  ON T.Name = D.Name	
GROUP BY D.Name, C.Name, T.total
ORDER BY D.Name

   
GO

SELECT   COUNT(R.Id)  AS number
    FROM Departments AS D
    JOIN Categories AS C
      ON C.DepartmentId = D.Id
    JOIN Reports AS R
      ON R.CategoryId = C.Id	
GROUP BY D.Name
