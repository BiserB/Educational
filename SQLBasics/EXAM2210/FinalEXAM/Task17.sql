USE ReportService
GO

CREATE FUNCTION udf_GetReportsCount(@employeeId INT, @statusId INT)
RETURNS INT
AS
BEGIN 
	RETURN
	ISNULL((
	SELECT COUNT(*)
	FROM Reports AS R	
	WHERE R.EmployeeId = @employeeId 
	  AND R.StatusId = @statusId
	  GROUP BY R.EmployeeId),0)	
END
---------------------------------------------------
GO
SELECT COUNT(*)
	
	SELECT COUNT(*)
	FROM Reports AS R	
	WHERE R.EmployeeId = 15 
	  AND R.StatusId = 4
	  GROUP BY R.EmployeeId


	  GO
	  SELECT * FROM Reports

GO
SELECT Id, FirstName, Lastname, dbo.udf_GetReportsCount(Id, 2) AS ReportsCount
FROM Employees
ORDER BY Id