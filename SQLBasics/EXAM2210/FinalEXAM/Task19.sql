
USE ReportService
GO

CREATE OR ALTER TRIGGER tr_StatusCompleted ON Reports
AFTER UPDATE
AS 
BEGIN 
		UPDATE Reports
		SET StatusId = 3
		WHERE Id = (SELECT i.Id FROM inserted AS i WHERE i.CloseDate IS NOT NULL)
	 
END





SELECT * FROM Employees
SELECT * FROM Reports

UPDATE Reports
SET CloseDate = GETDATE()
WHERE EmployeeId = 30;
