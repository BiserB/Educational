------------------------------------------1
USE SoftUni
GO
SELECT E.EmployeeID,
       E.JobTitle,
	   E.AddressID,
	   A.AddressText
FROM Employees AS E
JOIN Addresses AS A
ON (A.AddressID = E.AddressID) 

------------------------------------------2

SELECT TOP(50) E.FirstName,
	           E.LastName,
	           T.[Name],
	           A.AddressText
          FROM Employees AS E
    INNER JOIN Addresses AS A
            ON (A.AddressID = E.AddressID)
    INNER JOIN Towns AS T
            ON (T.TownID = A.TownID)
      ORDER BY E.FirstName, E.LastName

------------------------------------------3
With T(EmployeeID, FirstName, LastName, DepartmentName) 
    AS(
       SELECT E.EmployeeID,
	          E.FirstName,
	          E.LastName,
	          D.Name
         FROM Employees AS E
   INNER JOIN Departments AS D
           ON (D.DepartmentID = E.DepartmentID)
		   )
SELECT * FROM T
WHERE T.DepartmentName = 'Sales'
ORDER BY T.EmployeeID

------------------------------------------4

SELECT TOP(5) E.EmployeeID,
	          E.FirstName,
	          E.Salary,
	          D.Name AS DepartmentName
         FROM Employees AS E
   INNER JOIN Departments AS D
           ON (D.DepartmentID = E.DepartmentID) 
		WHERE Salary > 15000
	 ORDER BY E.DepartmentID

------------------------------------------5
SELECT TOP(3) E.EmployeeID,
	   E.FirstName
FROM Employees AS E
WHERE E.EmployeeID NOT IN
(
 SELECT    E.EmployeeID
      FROM Employees AS E
INNER JOIN EmployeesProjects AS EP
       ON (EP.EmployeeID = E.EmployeeID)
--INNER JOIN Projects AS P
	   --ON (P.ProjectID = EP.ProjectID)
	   )
	   ORDER BY E.EmployeeID


------------------5



SELECT TOP(3) EmployeeID,
	          FirstName
         FROM Employees
		 WHERE EmployeeID NOT IN (SELECT EmployeeID
									  FROM EmployeesProjects)
		 ORDER BY EmployeeID 

SELECT TOP 3 e.EmployeeID, FirstName
FROM Employees AS e 
LEFT JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
WHERE ProjectID IS NULL
--------------------------------------------------6

SELECT E.FirstName,
	   E.LastName,
	   E.HireDate,
	   D.Name AS DeptName
  FROM Employees AS E
  JOIN Departments AS D
    ON (D.DepartmentID = E.DepartmentID)
 WHERE E.HireDate > '1999/01/01' 
   AND D.Name IN ('Sales','Finance')
 ORDER BY E.HireDate

------------------------------------------------7
USE SoftUni
GO

SELECT TOP 5 E.EmployeeID,
       E.FirstName,
	   P.Name AS ProjectName
  FROM Employees AS E
  JOIN EmployeesProjects AS EP
    ON (EP.EmployeeID = E.EmployeeID)
  JOIN Projects AS P
    ON (P.ProjectID = EP.ProjectID)
 WHERE P.StartDate > '2002/08/13'	
   AND P.EndDate IS NULL   
 ORDER BY E.EmployeeID

 ------------------------------------------------14
USE Geography
GO
  SELECT TOP 5  C.CountryName, 
	            R.RiverName
           FROM Countries AS C
LEFT OUTER JOIN CountriesRivers AS CR
             ON (CR.CountryCode = C.CountryCode)
LEFT OUTER JOIN Rivers AS R
             ON (R.Id = CR.RiverId)
          WHERE C.ContinentCode  = 'AF'
       ORDER BY C.CountryName ASC

------------------------------------------------15
SELECT * FROM Countries
SELECT * FROM Continents

SELECT FS.ContinentCode,
	   FS.CurrencyCode,
	   FS.CurrencyUsage 
	FROM 
		(SELECT C.ContinentCode,
			    C.CurrencyCode,
	            COUNT (C.CurrencyCode) AS CurrencyUsage,
	            DENSE_RANK() OVER(PARTITION BY ContinentCode ORDER BY (COUNT(C.CurrencyCode)) DESC) AS RATED
	       FROM Countries AS C
	   GROUP BY C.ContinentCode, C.CurrencyCode
	     HAVING COUNT(C.CurrencyCode) > 1) AS FS
	WHERE RATED = 1

------------------------------------------------------------------16
          SELECT COUNT(*) AS CountryCode
			FROM Countries AS C
 LEFT OUTER JOIN MountainsCountries AS MC
 ON (MC.CountryCode = C.CountryCode)
 WHERE MountainId IS NULL
 ------------------------------------------------------------------17
 GO
 SELECT TOP 5 CountryName,
		MAX(HighestPeakElevation) AS HighestPeakElevation,
		MAX(LongestRiverLength) AS LongestRiverLength
    FROM(
         SELECT C.CountryName,
		        P.Elevation AS HighestPeakElevation,
				R.Length AS LongestRiverLength
           FROM Countries AS C
LEFT OUTER JOIN MountainsCountries AS MC
             ON (MC.CountryCode = C.CountryCode)
LEFT OUTER JOIN Peaks AS P
	         ON (P.MountainId = MC.MountainId)
LEFT OUTER JOIN CountriesRivers AS CR
             ON (CR.CountryCode = C.CountryCode)
LEFT OUTER JOIN Rivers AS R
			 ON (R.Id = CR.RiverId)
	       ) AS FS
	GROUP BY CountryName
	ORDER BY HighestPeakElevation DESC, LongestRiverLength DESC, CountryName
