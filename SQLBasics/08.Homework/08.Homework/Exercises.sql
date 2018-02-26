USE BANK
GO
USE SoftUni
GO

-----------------------------------------1

CREATE OR ALTER PROCEDURE dbo.usp_GetEmployeesSalaryAbove35000
AS 
SELECT E.FirstName,
	   E.LastName
FROM Employees AS E
WHERE E.Salary > 35000

----------------------------------------------------------2
GO
CREATE PROCEDURE usp_GetEmployeesSalaryAboveNumber @Threshold DECIMAL(18,4)
AS
BEGIN
	 SELECT E.FirstName,
	        E.LastName
	 FROM Employees AS E
	 WHERE E.Salary >= @Threshold
END

EXECUTE dbo.usp_GetEmployeesSalaryAboveNumber 48100

--------------------------------------------------------3
GO
CREATE PROCEDURE usp_GetTownsStartingWith @Input NVARCHAR(20)
AS
BEGIN
	 SELECT [T].[Name]
	 FROM Towns AS T
	 WHERE T.Name LIKE @Input + '%'
END

EXECUTE dbo.usp_GetTownsStartingWith b

--------------------------------------------------------4
GO

CREATE PROCEDURE usp_GetEmployeesFromTown @Town NVARCHAR(20)
AS
BEGIN
	SELECT E.FirstName,
	       E.LastName
	FROM Employees AS E
	JOIN Addresses AS A
	ON (A.AddressID = E.AddressID)
	JOIN Towns AS T
	ON(T.TownID = A.TownID)
	WHERE T.Name = @Town
END

EXECUTE dbo.usp_GetEmployeesFromTown Sofia

--------------------------------------------------5
GO
CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS NVARCHAR(10)
AS
BEGIN
    DECLARE @result NVARCHAR(10);
	SET @result = CASE		
		WHEN @salary < 30000 THEN 'Low'
		WHEN @salary > 50000 THEN 'High'
		ELSE 'Average'
		END
	RETURN @result;
END


GO
USE SoftUni
GO

SELECT E.Salary,
	   dbo.ufn_GetSalaryLevel(E.Salary) AS SalaryLevel
FROM Employees AS E

---------------------------------------------6
GO
CREATE PROCEDURE usp_EmployeesBySalaryLevel @Salary NVARCHAR(10)
AS
BEGIN
	SELECT E.FirstName,
		   E.LastName
	FROM Employees AS E
	WHERE dbo.ufn_GetSalaryLevel(E.Salary) = @Salary  
END

GO
EXECUTE usp_EmployeesBySalaryLevel Average


---------------------------------------------7
GO
CREATE OR ALTER FUNCTION ufn_IsWordComprised(@setOfLetters NVARCHAR(20), @word NVARCHAR(20))
RETURNS INT
AS
BEGIN
	
	WHILE(LEN(@word) > 0)
	 BEGIN
		DECLARE @letter NVARCHAR = LEFT(@word,1);
		SET @word = RIGHT(@word, LEN(@word)-1);
		IF(CHARINDEX(@letter, @setOfLetters) = 0 )
		 BEGIN
			SET @result = 0;
			BREAK
		 END
		
		 
		   SET @result = 1;
		 
	 END

	RETURN @result;
END

GO
SELECT 'oistmiahf' AS LETTER,	   
	   'SOFIA' AS word,
	   dbo.ufn_IsWordComprised('oistmiahf','SOFIA') AS RESULT

---------------------------------------------------------------8
GO
CREATE PROCEDURE usp_DeleteEmployeesFromDepartment (@departmentId INT)
AS
BEGIN
	ALTER TABLE Employees NOCHECK CONSTRAINT ALL
	ALTER TABLE EmployeesProjects NOCHECK CONSTRAINT ALL
	ALTER TABLE Departments NOCHECK CONSTRAINT ALL
	DELETE FROM Employees
	WHERE DepartmentID = @departmentId
	DELETE FROM Departments
	WHERE DepartmentID = @departmentId
	ALTER TABLE Employees WITH CHECK CHECK CONSTRAINT ALL
	ALTER TABLE EmployeesProjects WITH CHECK CHECK CONSTRAINT ALL
	ALTER TABLE Departments WITH CHECK CHECK CONSTRAINT ALL
END 


GO
SELECT * FROM Employees

	DELETE FROM Departments
	WHERE DepartmentID = 7

	DELETE FROM Employees
	WHERE DepartmentID = 7


ALTER TABLE Employees NOCHECK CONSTRAINT ALL
ALTER TABLE EmployeesProjects NOCHECK CONSTRAINT ALL
ALTER TABLE Departments NOCHECK CONSTRAINT ALL

EXEC sp_msforeachtable 'ALTER TABLE ? NOCHECK CONSTRAINT all'
EXEC sp_msforeachtable 'ALTER TABLE ? WITH CHECK CHECK CONSTRAINT all'

-----------------------------------------------------------------9
USE Bank
GO
SELECT * FROM AccountHolders
go

CREATE PROCEDURE usp_GetHoldersFullName
AS
BEGIN
	SELECT AH.FirstName + ' ' + AH.LastName AS [Full Name]
	FROM AccountHolders AS AH
END	

go
-------------------------------------------------------------10

CREATE PROCEDURE usp_GetHoldersWithBalanceHigherThan (@number INT)
AS
BEGIN
	SELECT AH.FirstName AS [First Name], 
		   AH.LastName AS [Last Name]
	FROM AccountHolders AS AH
	JOIN  (SELECT A.AccountHolderId, 
             SUM (A.Balance) AS Total
            FROM Accounts AS A
        GROUP BY A.AccountHolderId) AS TotalSum
	ON  (TotalSum.AccountHolderId = AH.Id)
	WHERE TotalSum.Total > @number
	ORDER BY [Last Name]
END

EXECUTE usp_GetHoldersWithBalanceHigherThan 50000

-------------------------------------------------------------10 review
GO

CREATE OR ALTER PROCEDURE usp_GetHoldersWithBalanceHigherThan (@number MONEY)
AS
BEGIN
	SELECT AH.FirstName,
		   AH.LastName
	FROM AccountHolders AS AH
	JOIN Accounts AS A
	ON (A.AccountHolderId = AH.Id)
	GROUP BY AH.FirstName, AH.LastName
	HAVING SUM(A.Balance) > @number
	ORDER BY AH.LastName, AH.FirstName
END




------------------------------------------------------11
GO 
CREATE OR ALTER FUNCTION ufn_CalculateFutureValue( @sum MONEY, @yearlyInterestRate FLOAT, @numberOfYears INT)
RETURNS MONEY
BEGIN
	DECLARE @result MONEY = @sum
	WHILE(@numberOfYears > 0)
		BEGIN
	    SET @result +=  @result * @yearlyInterestRate;
		SET @numberOfYears -= 1;
		END
	RETURN  @result
END

GO
SELECT dbo.ufn_CalculateFutureValue(1000, 0.1, 5)

--------------------------------------------------------12
GO
CREATE OR ALTER PROCEDURE usp_CalculateFutureValueForAccount(@AccountId INT, @yearlyInterestRate FLOAT)
AS
BEGIN
	DECLARE @balance MONEY
	SET @balance = (SELECT Balance FROM Accounts WHERE Id = @AccountId)	
	SELECT A.Id AS [Account Id],
		   AH.FirstName,
		   AH.LastName,
		   @balance AS [Current Balance],
		   dbo.ufn_CalculateFutureValue(@balance, @yearlyInterestRate,5) AS [Balance in 5 years]
	FROM Accounts AS A
	JOIN AccountHolders AS AH
	ON (AH.Id = A.AccountHolderId)
	WHERE A.Id = @AccountId
END

SELECT * FROM AccountHolders
SELECT * FROM Accounts

EXECUTE dbo.usp_CalculateFutureValueForAccount 2,0.1
		
----------------------------------------------------------13
GO
USE Diablo

SELECT * FROM Games
SELECT * FROM GameTypes


GO
CREATE FUNCTION ufn_CashInUsersGames (@gameName NVARCHAR(20))
RETURNS @result TABLE
( -- returned columns
SumCash
)
AS
BEGIN




END