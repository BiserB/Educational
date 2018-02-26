USE Gringotts
GO
SELECT * FROM WizzardDeposits

--------------------------------------- 1
SELECT COUNT(*) AS [Count] FROM WizzardDeposits
---------------------------------------2

SELECT TOP(1) MagicWandSize FROM WizzardDeposits
ORDER BY MagicWandSize DESC
---------------------------------------3
SELECT DepositGroup, MAX(MagicWandSize) AS [LongestMagicWand] FROM WizzardDeposits
GROUP BY DepositGroup


---------------------------------------4
SELECT TOP(2)DepositGroup  FROM WizzardDeposits
GROUP BY DepositGroup
ORDER BY AVG(MagicWandSize)


---------------------------------------5
SELECT DepositGroup, SUM(DepositAmount) AS [TotalSum]FROM WizzardDeposits
GROUP BY DepositGroup

---------------------------------------6
SELECT DepositGroup , SUM(DepositAmount)  AS [TotalSum]
FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup
--^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
SELECT  MagicWandCreator, COUNT(*) 
FROM WizzardDeposits
WHERE Age > 40
GROUP BY MagicWandCreator

---------------------------------------7
SELECT DepositGroup , SUM(DepositAmount)  AS [TotalSum]
FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family' 
GROUP BY DepositGroup
HAVING SUM(DepositAmount) < 150000
ORDER BY [TotalSum] DESC
---------------------------------------
SELECT [DepositGroup],
	   [MagicWandCreator],
	   MIN([DepositCharge]) AS MinDepositCharge 
FROM WizzardDeposits
GROUP BY [DepositGroup], [MagicWandCreator]
ORDER BY MagicWandCreator ASC, [DepositGroup] ASC


---------------------------------------9

USE Gringotts
GO
SELECT * FROM WizzardDeposits


SELECT AgeGroup , COUNT(*) AS WizardCount
FROM (
	  SELECT CASE
		    WHEN [Age] BETWEEN 0 AND 10 THEN '[0-10]'
			WHEN [Age] BETWEEN 11 AND 20 THEN '[11-20]'
			WHEN [Age] BETWEEN 21 AND 30 THEN '[21-30]'
			WHEN [Age] BETWEEN 31 AND 40 THEN '[31-40]'
			WHEN [Age] BETWEEN 41 AND 50 THEN '[41-50]'
			WHEN [Age] BETWEEN 51 AND 60 THEN '[51-60]'
			ELSE '[61+]'
			END AS [AgeGroup]
	  FROM WizzardDeposits) AS FirstSelect
GROUP BY FirstSelect.AgeGroup
		
---------------------------------------10 
SELECT DISTINCT LEFT(FirstName,1) AS FirstLetter
FROM WizzardDeposits
WHERE DepositGroup = 'Troll Chest'
GROUP BY FirstName

---------------------------------------11
USE Gringotts
GO
SELECT * FROM WizzardDeposits

SELECT DepositGroup, IsDepositExpired, AVG(DepositInterest) AS AverageInterest
FROM WizzardDeposits
WHERE DepositStartDate > '1985-01-01'
GROUP BY DepositGroup, IsDepositExpired
ORDER BY DepositGroup DESC, IsDepositExpired ASC

---------------------------------------12
USE Gringotts
GO
SELECT SUM(FirstSelect.Diff) AS SumDifference
FROM( 
	SELECT	[FirstName],
			[DepositAmount] AS HostDepozit,
			LEAD ([DepositAmount]) OVER (ORDER BY [Id]) AS GuestDepozit,
			[DepositAmount] - LEAD ([DepositAmount]) OVER (ORDER BY [Id]) AS Diff
	FROM WizzardDeposits
	)AS FirstSelect




---------------------------------------13
USE SoftUni
GO
SELECT * FROM Employees


SELECT DepartmentID, SUM(Salary) AS TotalSalary
FROM Employees
GROUP BY DepartmentID
ORDER BY DepartmentID
---------------------------------------14
SELECT DepartmentID, Min(Salary) AS MinimumSalary
FROM Employees
WHERE DepartmentID IN (2,5,7)
GROUP BY DepartmentID

SELECT DepartmentID, Min(Salary) AS MinimumSalary
FROM Employees
GROUP BY DepartmentID
HAVING  DepartmentID IN (2,5,7)

---------------------------------------15
DROP TABLE EmployeesII

SELECT * INTO EmployeesII FROM Employees
WHERE Salary > 30000 

DELETE  FROM EmployeesII
WHERE	ManagerID = '42'

UPDATE EmployeesII
SET Salary += 5000
WHERE  DepartmentID = 1 

SELECT DepartmentID, AVG(Salary) AS AverageSalary FROM EmployeesII
GROUP BY DepartmentID

---------------------------------------16
SELECT DepartmentID, MAX(Salary) AS MaxSalary
FROM Employees
GROUP BY DepartmentID
HAVING MAX(Salary) NOT BETWEEN 30000 AND 70000


---------------------------------------17
SELECT Count(Salary) AS [Count] FROM Employees
WHERE ManagerID IS NULL

--------------------------------------- 18 *
USE SoftUni
GO
SELECT * FROM Employees

SELECT S.DepartmentID, S.Salary AS ThirdHighestSalary
FROM (SELECT	[DepartmentID],
		[Salary], 
		ROW_NUMBER() OVER(PARTITION BY [DepartmentID] ORDER BY [Salary]DESC ) AS [Row]
	 FROM Employees
	 GROUP BY [DepartmentID], [Salary]) AS S
WHERE S.Row = 3

----------

SELECT S.DepartmentID, S.Salary AS ThirdHighestSalary
FROM (SELECT	[DepartmentID],
		[Salary], 
		ROW_NUMBER() OVER(PARTITION BY [DepartmentID] ORDER BY [Salary]DESC ) AS [Row]
	 FROM Employees) AS S
WHERE S.Row = 3

--------------------------------------- 19 *


SELECT AVG(Salary) AS Average,
	   [DepartmentID] AS Dep
	   INTO AVER
FROM Employees 
GROUP BY [DepartmentID]

SELECT TOP(10) E.[FirstName],E.[LastName],E.[DepartmentID]  
FROM Employees AS E
INNER JOIN AVER ON E.DepartmentID = AVER.Dep
WHERE E.Salary > AVER.Average
ORDER BY E.DepartmentID
				





---------------------------------------


---------------------------------------
---------------------------------------


---------------------------------------
---------------------------------------

USE AdventureWorksLT2012
SELECT * FROM SalesLT.SalesOrderHeader

SELECT ProductID, MAX(UnitPrice) FROM SalesLT.SalesOrderDetail
GROUP BY ProductID

SELECT CustomerID, OrderDate, SubTotal, TotalDue
FROM SalesLT.SalesOrderHeader
WHERE SalesOrderID < 71856
ORDER BY OrderDate 

SELECT ROW_NUMBER()
OVER(PARTITION BY CustomerID ORDER BY CustomerID)
FROM SalesLT.SalesOrderHeader
AS Row


SELECT SalesOrderID, ROW_NUMBER( OVER() ORDER BY SalesOrderID)
FROM SalesLT.SalesOrderHeader

USE SoftUni
go
SELECT * FROM ExamResult2
DELETE FROM ExamResult2

Create table ExamResult2(ID INT IDENTITY,name varchar(50),Subject varchar(20),Marks int)

insert into ExamResult2 values('Adam','Maths',70)
insert into ExamResult2 values ('Adam','Science',80)
insert into ExamResult2 values ('Adam','Social',60)

insert into ExamResult2 values('Rak','Maths',60)
insert into ExamResult2 values ('Rak','Science',50)
insert into ExamResult2 values ('Rak','Social',70)

insert into ExamResult2 values('Sam','Maths',90)
insert into ExamResult2 values ('Sam','Science',90)
insert into ExamResult2 values ('Sam','Social',80)

SELECT ER.[Name], ER.[Marks]
FROM (SELECT [Name],[Subject],[Marks], 
ROW_NUMBER() OVER(PARTITION BY [name]order by [Marks])[Row]
FROM ExamResult) AS ER
WHERE ER.Row = 3


SELECT [Name],[Subject],[Marks], 
RANK() OVER(PARTITION BY [name] order by [Marks] DESC)[Rank]
FROM ExamResult

CREATE TABLE TestEmployees(
ID INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(50)
)

CREATE TABLE TestProjects(
ID INT PRIMARY KEY,
Project NVARCHAR(50)
)

CREATE TABLE TestEmployeesProjects(
EmployeeID INT,
ProjectID INT,
CONSTRAINT PK_EmplP PRIMARY KEY( EmployeeID, ProjectID),
CONSTRAINT FK_TestEmployeesProjects FOREIGN KEY (EmployeeID) REFERENCES TestEmployees(ID),
CONSTRAINT FK_TestEmployeesProjects2 FOREIGN KEY (ProjectID) REFERENCES TestProjects(ID)
)

INSERT INTO TestEmployees VALUES
('Alex Brood'),('Pesho Kolev'),('Mamsi Jayson'),('Michel Lin')
INSERT INTO TestProjects VALUES
(1, 'GAMES'),(2, 'WEB'),(3, 'APP')
INSERT INTO TestEmployeesProjects VALUES
(1,23),(1,22),(2,21),(3,21),(4,21)

SELECT [Name],TestProjects.Project
FROM TestEmployees JOIN TestProjects
ON TestEmployees.ID = TestProjects.ID

SELECT * 