------------------------------------------------------1
USE Gringotts
GO
SELECT COUNT(*) AS [Count]
FROM WizzardDeposits

------------------------------------------------------2
SELECT MAX(MagicWandSize) as LongestMagicWand
FROM WizzardDeposits

------------------------------------------------------3
SELECT W.DepositGroup, MAX(W.MagicWandSize) AS LongestMagicWand
FROM WizzardDeposits AS W
GROUP BY W.DepositGroup

------------------------------------------------------4
SELECT TOP(2) W.DepositGroup
		 FROM WizzardDeposits AS W
     GROUP BY W.DepositGroup
     ORDER BY AVG(W.MagicWandSize) ASC

------------------------------------------------------5

SELECT W.DepositGroup, SUM(W.DepositAmount) AS TotalSum
FROM WizzardDeposits AS W
GROUP BY W.DepositGroup

------------------------------------------------------6

SELECT W.DepositGroup, SUM(W.DepositAmount) AS TotalSum
FROM WizzardDeposits AS W
WHERE W.MagicWandCreator = 'Ollivander Family'
GROUP BY W.DepositGroup

------------------------------------------------------7

SELECT W.DepositGroup, SUM(W.DepositAmount) AS TotalSum
FROM WizzardDeposits AS W
WHERE W.MagicWandCreator = 'Ollivander Family'
GROUP BY W.DepositGroup
HAVING SUM(W.DepositAmount) < 150000
ORDER BY [TotalSum] DESC

------------------------------------------------------8

  SELECT W.DepositGroup, 
		 W.MagicWandCreator, 
		 MIN(W.DepositCharge) AS MinDepositCharge
    FROM WizzardDeposits AS W
GROUP BY W.DepositGroup, W.MagicWandCreator
ORDER BY W.MagicWandCreator, W.DepositGroup

------------------------------------------------------9

SELECT FS.AgeGroup,
	   COUNT(*) AS WizardCount
FROM
  (
  SELECT AgeGroup = (CASE 
				WHEN W.Age BETWEEN 0 AND 10 THEN '[0-10]'
				WHEN W.Age BETWEEN 11 AND 20 THEN '[11-20]'
				WHEN W.Age BETWEEN 21 AND 30 THEN '[21-30]'
				WHEN W.Age BETWEEN 31 AND 40 THEN '[31-40]'
				WHEN W.Age BETWEEN 41 AND 50 THEN '[41-50]'
				WHEN W.Age BETWEEN 51 AND 60 THEN '[51-60]'
				ELSE '[61+]'	
				END)
    FROM WizzardDeposits AS W    
	) AS FS
	GROUP BY FS.AgeGroup

------------------------------------------------------10

SELECT LEFT(W.FirstName,1) AS [FirstLetter]
FROM WizzardDeposits AS W
WHERE W.DepositGroup = 'Troll Chest'
GROUP BY LEFT(W.FirstName,1)
ORDER BY [FirstLetter]

------------------------------------------------------11

 SELECT W.DepositGroup,
		W.IsDepositExpired,
		AVG(W.DepositInterest) AS AverageInterest
FROM WizzardDeposits AS W
WHERE W.DepositStartDate > '1985/01/01'
GROUP BY W.DepositGroup, W.IsDepositExpired
ORDER BY W.DepositGroup DESC, W.IsDepositExpired ASC
------------------------------------------------------12
SELECT SUM(FS.[Difference]) AS SumDifference
FROM (
    SELECT W.FirstName AS [Host Wizard],
		   W.DepositAmount AS [Host Wizard Deposit],
		   W2.FirstName AS [Guest Wizard],
		   W2.DepositAmount AS [Guest Wizard Deposit],
		   W.DepositAmount - W2.DepositAmount AS [Difference]
	  FROM WizzardDeposits AS W
INNER JOIN WizzardDeposits AS W2
ON (W2.Id = W.Id + 1)
) AS FS

SELECT * FROM WizzardDeposits

------------------------------------------------------13
USE SoftUni
GO

SELECT E.DepartmentID,
		SUM(E.Salary) AS TotalSalary
FROM Employees AS E
GROUP BY E.DepartmentID