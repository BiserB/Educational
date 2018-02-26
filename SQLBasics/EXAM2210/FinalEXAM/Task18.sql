USE ReportService
GO

CREATE PROCEDURE usp_AssignEmployeeToReport @employeeId INT, @reportId INT
AS
BEGIN
	DECLARE @EmplDep INT = 
	(SELECT E.DepartmentId FROM Employees AS E WHERE E.Id = @employeeId)
	DECLARE @RepDep INT = 
	(SELECT C.DepartmentId FROM Reports AS R JOIN Categories AS C ON C.Id = R.CategoryId 
	WHERE R.Id = @reportId )
	BEGIN TRANSACTION
		IF (@EmplDep = @RepDep)
		 BEGIN
			UPDATE Reports
			SET EmployeeId = @employeeId
			WHERE Id = @reportId 
		 END
		ELSE
		 BEGIN
			ROLLBACK
			RAISERROR('Employee doesn''t belong to the appropriate department!',16,1)
		 END
	COMMIT
END



GO 
SELECT * FROM Employees

 SELECT * FROM Reports

 EXEC usp_AssignEmployeeToReport 17, 2;

 SELECT EmployeeId FROM Reports WHERE id = 2