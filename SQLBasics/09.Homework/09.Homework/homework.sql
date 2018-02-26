USE Bank
GO
--------------------------------------------1
CREATE TABLE Logs (
LogId INT PRIMARY KEY IDENTITY, 
AccountId INT NOT NULL, 
OldSum DECIMAL(15,2) NOT NULL, 
NewSum  DECIMAL(15,2) NOT NULL
)
GO

CREATE  TRIGGER tr_changeLog
 ON dbo.Accounts
 AFTER UPDATE
AS 
BEGIN
	BEGIN
		INSERT INTO Logs(AccountId, OldSum, NewSum) 
		SELECT i.Id,
			   d.Balance,
			   i.Balance
		FROM inserted AS i
		JOIN deleted AS d
		ON (d.Id = i.Id)
	END
END


SELECT * FROM Accounts
SELECT * FROM Logs
DELETE  FROM Logs

SELECT * FROM NotificationEmails
DELETE FROM NotificationEmails

UPDATE  Accounts
SET Balance = 1000
where Id = 1

DROP TRIGGER changeLog

-------------------------------------------------------2
GO
USE Bank
GO


CREATE TABLE NotificationEmails(
Id INT PRIMARY KEY IDENTITY , 
Recipient NVARCHAR(50) NOT NULL, 
Subject NVARCHAR(50) NOT NULL, 
Body NVARCHAR(MAX) NOT NULL
)

GO

CREATE TRIGGER tr_notification
 ON dbo.Logs
 AFTER INSERT
AS
BEGIN
	INSERT INTO NotificationEmails(Recipient, Subject, Body) 
	SELECT inserted.AccountId,	
		   CONCAT ('Balance change for account: ' , inserted.AccountId),
		   CONCAT ('On ', GETDATE(),' your balance was changed from ', inserted.OldSum ,' to ', inserted.NewSum,'.')
	  FROM inserted	  
END

---------------------------------------------------------------3
GO
USE Bank
GO

DROP PROC dbo.usp_DepositMoney

GO
CREATE or alter PROCEDURE dbo.usp_DepositMoney (@AccountId INT, @MoneyAmount DECIMAL(15,4))
AS
BEGIN 
	IF (NOT EXISTS(SELECT * FROM Accounts AS A WHERE A.Id =  @AccountId))
	 BEGIN	  
	  RAISERROR ('INVALID ACCOUNT!',16,1)
	  RETURN
	 END
	 IF (@MoneyAmount < 0)
	 BEGIN
	 RAISERROR ('INVALID AMMOUNT!',16,2)
	 END
    BEGIN TRANSACTION
	UPDATE Accounts
	SET Balance +=  @MoneyAmount
	WHERE Accounts.Id = @AccountId
	IF (@@ROWCOUNT <> 1)
	 BEGIN
	  ROLLBACK
	  RAISERROR ('ERROR!', 16,3)
	  RETURN
	 END 
	COMMIT 
END

GO
EXEC usp_DepositMoney 1,0

SELECT * FROM Accounts


--------------------------------------------------------------4
GO

CREATE or alter PROCEDURE dbo.usp_WithdrawMoney (@AccountId INT, @MoneyAmount DECIMAL(15,4))
AS
BEGIN
	IF (NOT EXISTS(SELECT * FROM Accounts AS A WHERE A.Id =  @AccountId))
	 BEGIN	  
	  RAISERROR ('INVALID ACCOUNT!',16,1)
	  RETURN
	 END
	 IF (@MoneyAmount > (SELECT A.Balance FROM Accounts AS A WHERE A.Id =  @AccountId))
	 BEGIN
	 RAISERROR ('INSUFFICIENT AMMOUNT!',16,2)
	 END
	 BEGIN TRANSACTION
	  UPDATE Accounts
	  SET Balance -= @MoneyAmount
	  WHERE Accounts.Id = @AccountId
	  IF(@@ROWCOUNT <> 1)
	   BEGIN
	    ROLLBACK
		RAISERROR('ERROR!',16,3)
		RETURN
	   END
	 COMMIT
END

GO
EXEC dbo.usp_WithdrawMoney 5,25.0001
SELECT * FROM Accounts

------------------------------------------------------------5
GO
USE Bank
GO

CREATE OR ALTER PROCEDURE usp_TransferMoney(@SenderId INT, @ReceiverId INT, @Amount DECIMAL(15,4))
AS
BEGIN
	IF(    EXISTS(SELECT * FROM Accounts WHERE Id = @SenderId)
	   AND  EXISTS(SELECT * FROM Accounts WHERE Id = @ReceiverId))
	 BEGIN	
	  EXEC dbo.usp_WithdrawMoney @SenderId, @Amount	
	  EXEC dbo.usp_DepositMoney @ReceiverId, @Amount
	 END
	ELSE
	 BEGIN
	 RAISERROR('ERROR!',16,3)
	 END	
END

EXEC usp_TransferMoney 1,200,0.0001

SELECT * FROM Accounts

----------------------------------------------------------------6
GO
USE Diablo
GO

SELECT * 
FROM Users AS U
WHERE U.Username IN( 'baleremuda', 'loosenoise', 'inguinalself', 'buildingdeltoid', 'monoxidecos')

GO
CREATE TRIGGER tr_BuyRestriction

----------------------------------------------------------------7*




----------------------------------------------------------------8
GO
USE SoftUni
GO
SELECT *
FROM EmployeesProjects
where 
GO

CREATE PROCEDURE usp_AssignProject(@emloyeeId INT, @projectID INT)
AS
BEGIN
	BEGIN TRANSACTION
	DECLARE @ProjectsCount INT = 0;	
	INSERT INTO EmployeesProjects (EmployeeID, ProjectID) VALUES
				(@emloyeeId, @projectID)	
	SET @ProjectsCount = (SELECT COUNT(EP.ProjectID) 
						    FROM EmployeesProjects AS EP 
						   WHERE EP.EmployeeID = @emloyeeId)
	IF(@ProjectsCount > 3)
	 BEGIN
		ROLLBACK
		RAISERROR('The employee has too many projects!',16,1)
	 END	
	COMMIT
END

GO
exec usp_AssignProject 1, 11


------------------------------------------------------------------9

USE [SoftUni]
GO

CREATE TABLE [dbo].[Deleted_Employees](
	[EmployeeID] [int] PRIMARY KEY IDENTITY NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[MiddleName] [varchar](50) NULL,
	[JobTitle] [varchar](50) NOT NULL,
	[DepartmentID] [int] NOT NULL,
	[Salary] [money] NOT NULL
	)
GO

CREATE TRIGGER tr_DeletedEmployees
 ON dbo.Employees
 AFTER DELETE
AS
BEGIN
 INSERT INTO [Deleted_Employees] 
      SELECT FirstName,
			 LastName,
			 MiddleName,
			 JobTitle,
			 DepartmentID,
			 Salary
	  FROM deleted
END
 
GO
delete FROM Employees
where EmployeeID =3
