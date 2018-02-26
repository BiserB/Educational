USE SoftUni
GO
SELECT [FirstName],[LastName] FROM Employees
WHERE [FirstName] LIKE 'sa%'

---------------------------------------------
SELECT [FirstName],[LastName] FROM Employees
WHERE CONTAINS (FirstName,'S%')
---------------------------------------------

SELECT [FirstName],[LastName] FROM Employees
WHERE [LastName] LIKE '%ei%'

---------------------------------------------

SELECT [FirstName] FROM Employees
WHERE [DepartmentID] IN (3,10)
AND DATEPART(YYYY, HireDate) BETWEEN 1995 AND 2005

---------------------------------------------

SELECT [FirstName],[LastName] FROM Employees
where [JobTitle] NOT LIKE '%engineer%'

SELECT [FirstName],[LastName] FROM Employees
where [JobTitle] != '%engineer%'

---------------------------------------------

SELECT [Name] FROM Towns
WHERE LEN([Name]) IN (5,6)
ORDER BY [Name]
---------------------------------------------6
SELECT * FROM Towns
WHERE SUBSTRING([Name],1,1) = 'M' 
OR SUBSTRING([Name],1,1) = 'E'
OR SUBSTRING([Name],1,1) = 'K' 
OR SUBSTRING([Name],1,1) = 'B'
ORDER BY [Name]

---------------------------------------------6
SELECT * FROM Towns
WHERE	[Name] LIKE 'M%'
	 OR [Name] LIKE 'E%'
	 OR [Name] LIKE 'K%'
	 OR [Name] LIKE 'B%'
ORDER BY [Name]
---------------------------------------------
SELECT * FROM Towns
WHERE [Name] LIKE '[MEKB]%'
ORDER BY [Name]
---------------------------------------------
SELECT * FROM Towns
WHERE SUBSTRING([Name],1,1) != 'R' 
AND SUBSTRING([Name],1,1) != 'B'
AND SUBSTRING([Name],1,1) != 'D'
ORDER BY [Name]
GO
---------------------------------------------

CREATE VIEW V_EmployeesHiredAfter2000 AS
SELECT [FirstName],[LastName] FROM Employees
WHERE DATEPART(YYYY, [HireDate]) > 2000

DROP VIEW V_EmployeesHiredAfter2000
SELECT* FROM V_EmployeesHiredAfter2000
GO
---------------------------------------------
SELECT FirstName, LastName FROM Employees
WHERE LEN(LastName) = 5

---------------------------------------------10
USE Geography
GO
SELECT * FROM Countries
SELECT [CountryName],[IsoCode] FROM Countries
WHERE [CountryName] LIKE ('%a%a%a%')
ORDER BY IsoCode

---------------------------------------------11
USE Geography
GO
select * from Peaks
select * from Rivers

SELECT P.PeakName, R.RiverName,
LOWER(CONCAT(LEFT(PeakName,LEN(PeakName)-1),RiverName)) AS MIX
FROM Peaks AS P,Rivers AS R
WHERE RIGHT([PeakName],1 ) = LEFT([RiverName],1)
ORDER BY MIX

---------------------------------------------12
USE Diablo
GO

SELECT TOP(50) [Name], CONVERT(date,[Start]) AS Start  FROM Games
WHERE DATEPART(YYYY,[Start]) BETWEEN 2011 AND 2012
ORDER BY [Start],[Name]

SELECT TOP(50) [Name], FORMAT([Start], 'yyyy-MM-dd') AS Start  FROM Games
WHERE DATEPART(YYYY,[Start]) BETWEEN 2011 AND 2012
ORDER BY [Start],[Name]

SELECT * FROM Games

SELECT TOP(50) [Name], CONVERT(VARCHAR(10),[Start],23) AS Start  FROM Games
WHERE DATEPART(YEAR,[Start]) BETWEEN '2011' AND '2012'
ORDER BY [Start],[Name]

---------------------------------------------13
SELECT * FROM Users
SELECT [Username], RIGHT(Email,LEN(Email) - CHARINDEX('@', Email)) AS [Provider]
FROM Users
ORDER BY [Provider], [Username]

--------------------------------------------- 14
USE Diablo
GO
SELECT [Username],[IpAddress] FROM Users
WHERE [IpAddress] LIKE ('___.1%.%.___')
ORDER BY [Username] ASC

---------------------------------------------15
SELECT * FROM Games
ORDER BY [Name]

SELECT [Name] AS [Game],
	   CASE WHEN DATEPART(HOUR,[Start]) BETWEEN 0 AND 11 THEN 'Morning'
			WHEN DATEPART(HOUR,[Start]) BETWEEN 12 AND 17 THEN 'Afternoon'
			WHEN DATEPART(HOUR,[Start]) BETWEEN 18 AND 23 THEN 'Evening'
			END
			AS [Part of the Day],
	   CASE WHEN [Duration] <= 3 THEN 'Extra Short'
			WHEN [Duration] BETWEEN 4 AND 6 THEN 'Short'
			WHEN [Duration] > 6 THEN 'Long'
			ELSE 'Extra Long'
			END
			AS [Duration]
FROM Games
ORDER BY [Game] ASC, [Duration] ASC, [Part of the Day] ASC

---------------------------------------------16
USE Orders
GO
SELECT [ProductName],
	   [OrderDate],
	   DATEADD(DAY,3,OrderDate) AS [Pay Due], 
	   DATEADD(MONTH,1,OrderDate) AS [Delivery Due] 
FROM Orders

---------------------------------------------22
CREATE TABLE PEOPLE(
ID INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(50) NOT NULL,
[Birthday] DATETIME NOT NULL
)
USE Orders
GO

ALTER TABLE PEOPLE
ALTER COLUMN Birthday DATE NOT NULL

SET DATEFORMAT dmy;  
GO  

INSERT INTO PEOPLE ([Name],Birthday) VALUES
('Tedi', '15-05-2003'),
('Ssssss', '9-06-2009'),
('Bobson', '29-07-2008'),
('Goshoo', '06-06-2006'),
('Vankoo', '09-12-2000'),
('Alexo', '04-03-2010')

USE Orders
GO

SELECT [Name],
		CONVERT(CHAR(10),[Birthday], 110) AS Birthday,
		DATEDIFF(YEAR, [Birthday], GETDATE()  ) AS [Age in Years],
		DATEDIFF(MONTH, [Birthday], GETDATE()  ) AS [Age in Months],
		DATEDIFF(DAY, [Birthday], GETDATE()  ) AS [Age in Days],
		DATEDIFF(MINUTE, [Birthday], GETDATE()  ) AS [Age in Minutes]
FROM PEOPLE

