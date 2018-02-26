USE SoftUni
GO
-------------------------------------1
SELECT TOP(5) [EmployeeID],[JobTitle],Employees.[AddressID],[Addresses].[AddressText]
FROM Employees
JOIN Addresses ON (Employees.[AddressID] = [Addresses].[AddressID])
ORDER BY Employees.[AddressID] ASC

SELECT * FROM Addresses
SELECT * FROM Employees
SELECT * FROM EmployeesProjects


------------------------------------------2
--

SELECT TOP(50)[Employees].[FirstName], [Employees].[LastName], [Towns].[Name], [Addresses].[AddressText]
FROM Addresses
JOIN Employees ON ( [Addresses].[AddressID] = [Employees].[AddressID])
JOIN Towns ON ([Addresses].[TownID] = [Towns].[TownID])
ORDER BY [Employees].[FirstName], [Employees].[LastName]

----------------------------------



----------------------------------3

SELECT E.[EmployeeID], E.[FirstName],E.[LastName], D.[Name] AS DepartmentName
	FROM Employees AS E
	JOIN Departments AS D
	  ON (D.DepartmentID = E.DepartmentID)
   WHERE D.Name = 'Sales'

----------------------------------4

SELECT TOP(5) E.EmployeeID, E.FirstName, E.Salary, D.[Name] AS DepartmentName
	  FROM Employees AS E
INNER JOIN Departments AS D
		ON (D.DepartmentID = E.DepartmentID)
	 WHERE E.Salary > 15000
  ORDER BY E.DepartmentID ASC

  ----------------------------------5
  SELECT * FROM Employees
  SELECT * FROM EmployeesProjects
SELECT * FROM Projects

--------------------------------xx
  SELECT TOP(3) E.EmployeeID, E.FirstName 
    FROM Employees AS E
	JOIN EmployeesProjects AS EP
	ON (EP.EmployeeID <> E.EmployeeID)
	WHERE EP.ProjectID IS NULL
	ORDER BY E.EmployeeID ASC
---------------------------------xx

SELECT TOP(3) E.EmployeeID, E.FirstName 
		 FROM Employees AS E
	    WHERE E.EmployeeID NOT IN 
				(
				SELECT EmployeeID
				FROM EmployeesProjects
				GROUP BY EmployeeID
				)
		ORDER BY E.EmployeeID ASC
		
----------------------------------6

    SELECT E.FirstName, E.LastName, E.HireDate, D.[Name] AS DeptName
      FROM Employees AS E
INNER JOIN Departments AS D
	    ON (D.DepartmentID = E.DepartmentID
	   AND e.HireDate > '01/01/1999'
	   AND D.Name IN ('Sales', 'Finance'))
  ORDER BY E.HireDate ASC

	-----

    SELECT E.FirstName, E.LastName, E.HireDate, D.[Name] AS DeptName
      FROM Employees AS E
INNER JOIN Departments AS D
	    ON (D.DepartmentID = E.DepartmentID)
	   WHERE e.HireDate > '01/01/1999'
	   AND D.Name IN ('Sales', 'Finance')
  ORDER BY E.HireDate ASC

  -------------------------------------------7
  SELECT * FROM Employees
    SELECT * FROM EmployeesProjects
    SELECT * FROM Projects

SELECT TOP(5) E.EmployeeID, E.FirstName, P.[Name] AS ProjectName
	     FROM Employees AS E
   INNER JOIN EmployeesProjects AS EP
		   ON (EP.EmployeeID = E.EmployeeID)
   INNER JOIN Projects AS P
		   ON (P.ProjectID  = EP.ProjectID) 
		WHERE P.EndDate IS NULL
	      AND P.StartDate > '2002/08/13'
	 ORDER BY E.EmployeeID ASC


	 ----
	SELECT P.ProjectID, P.[Name]
	FROM Projects AS P
	WHERE P.EndDate IS NULL
	AND P.StartDate > '2002/08/13'

	------------------------------------------8
	SELECT E.EmployeeID,
		   E.FirstName,
		   ProjectName =(CASE  
							WHEN P.StartDate > '2005/01/01' THEN  NULL
							ELSE P.[Name] 
							END )
	  FROM Employees AS E	
INNER JOIN EmployeesProjects AS EP
		ON (EP.EmployeeID = E.EmployeeID)
INNER JOIN Projects AS P
		ON (P.ProjectID  = EP.ProjectID)		
	 WHERE (E.EmployeeID = 24)
	 
-------------------------------------------9

   SELECT  E.EmployeeID, 
		   E.FirstName, 
		   E.ManagerID, 
		   E2.FirstName AS ManagerName 
	  FROM Employees AS E
INNER JOIN Employees AS E2
	    ON (E2.EmployeeID = E.ManagerID)
	 WHERE E.ManagerID IN (3,7)
  ORDER BY E.EmployeeID
	
	
	SELECT * FROM Employees	 
	SELECT * FROM Departments	 
	USE master
----------------------------------------------10
USE SoftUni GO

SELECT TOP(50) E.EmployeeID, 
		   E.FirstName +' '+ E.LastName AS EmployeeName,
		   E2.FirstName +' '+ E2.LastName AS ManagerName, 
		   D.Name AS DepartmentName
	  FROM Employees AS E
INNER JOIN Employees AS E2
		ON (E2.EmployeeID = E.ManagerID)
INNER JOIN Departments AS D
		ON (D.DepartmentID = E.DepartmentID)
  ORDER BY E.EmployeeID



	  SELECT * FROM Departments
	  SELECT * FROM Employees
---------------------------------------------11

SELECT TOP(1) AVG(E.Salary) AS MinAverageSalary
FROM Employees AS E
GROUP BY E.DepartmentID
ORDER BY AVG(E.Salary)

--------------SECOND WAY

SELECT MIN(AvgSalary) AS MinAverageSalary 
  FROM(
		  SELECT AVG(E.Salary) AS AvgSalary
		    FROM Employees AS E
		GROUP BY E.DepartmentID 
		       ) AS EmpAvgSalary

---------------------------------------------12
USE Geography
go

    SELECT MC.CountryCode, M.MountainRange, P.PeakName, P.Elevation
      FROM MountainsCountries AS MC
INNER JOIN Mountains AS M
        ON (M.Id = MC.MountainId)
INNER JOIN Peaks AS P
        ON (P.MountainId = M.Id)
     WHERE MC.CountryCode = 'BG' 
       AND P.Elevation > 2835
  ORDER BY P.Elevation DESC

--------------------------------------------13
USE Geography
GO
SELECT CountryCode, COUNT(MountainRange) AS MountainRanges
FROM
 (SELECT MC.CountryCode, M.MountainRange
 FROM MountainsCountries AS MC
 INNER JOIN Mountains AS M
 ON (M.Id = MC.MountainId)
 ) AS CountryRanges
 GROUP BY CountryCode
 HAVING CountryCode IN ('BG', 'US', 'RU')

 --------------------------------------------14

SELECT TOP(5) C.CountryName, R.RiverName
       FROM Countries AS C
LEFT OUTER JOIN CountriesRivers AS CR
         ON (CR.CountryCode = C.CountryCode)
LEFT OUTER JOIN Rivers AS R
         ON (R.Id = CR.RiverId)
      WHERE C.ContinentCode = 'AF'
   ORDER BY CountryName

  --------------------------------------------15??
 

 -----
  SELECT 
		 FS.ContinentCode,
		 FS.CurrencyCode,
		 FS.CurrencyUsage
 FROM 
   (SELECT C.ContinentCode,
		   C.CurrencyCode,
	 COUNT (C.CurrencyCode) AS CurrencyUsage,
	 DENSE_RANK() OVER(PARTITION BY C.ContinentCode  ORDER BY COUNT (C.CurrencyCode) DESC) AS GRADE
      FROM Countries AS C
  GROUP BY C.ContinentCode, C.CurrencyCode) AS FS
  WHERE GRADE = 1 AND CurrencyUsage > 1
	
	 


  
 
 
 
  


 ----------------------------------------------16
 SELECT COUNT(*) AS CountryCode
   FROM Countries
  WHERE Countries.CountryCode NOT IN
      (
      SELECT C.CountryCode
        FROM Countries AS C
        JOIN MountainsCountries AS MC
          ON (MC.CountryCode = C.CountryCode)
	   )
-------------------------------------------------17
SELECT TOP(5)FS.CountryName,
		MAX(FS.Elevation) AS HighestPeakElevation,
		MAX(FS.Length) AS LongestRiverLength
FROM 
     (
	SELECT C.CountryName, P.Elevation, R.Length
	  FROM Countries AS C
      JOIN MountainsCountries AS MC
        ON (MC.CountryCode = C.CountryCode)
      JOIN Peaks AS P
        ON (P.MountainId = MC.MountainId)
      JOIN CountriesRivers AS CR
        ON (CR.CountryCode = C.CountryCode)
      JOIN Rivers AS R
       ON (R.Id = CR.RiverId)
      ) AS FS 
GROUP BY FS.CountryName
ORDER BY HighestPeakElevation DESC, 
         LongestRiverLength DESC, 
		 CountryName
------------------------------------------18

SELECT  TOP(5) FS.Country,
	           FS.[Highest Peak Name],
	           FS.[Highest Peak Elevation],
	           FS.Mountain
          FROM
             (
			SELECT  C.CountryName AS [Country],
		 COALESCE (P.PeakName, '(no highest peak)') AS [Highest Peak Name],
		 COALESCE (P.Elevation,0) AS [Highest Peak Elevation],
	     COALESCE (M.MountainRange,'(no mountain)') AS [Mountain],
	 DENSE_RANK() OVER(PARTITION BY C.CountryName ORDER BY COALESCE(P.Elevation,0) DESC) AS GRADE
             FROM Countries AS C
  LEFT OUTER JOIN MountainsCountries AS MC
               ON (MC.CountryCode = C.CountryCode)
  LEFT OUTER JOIN Mountains AS M
               ON (M.Id = MC.MountainId)
  LEFT OUTER JOIN Peaks AS P
               ON (P.MountainId = MC.MountainId)
                ) AS FS ---- FS  is First Selection
            WHERE FS.GRADE = 1
         ORDER BY [Country], [Highest Peak Name]


-----

----------------------------------------------------- TEST

SELECT C.ContinentCode
FROM Countries AS C
ORDER BY DENSE_RANK() OVER(PARTITION BY C.ContinentCode )



