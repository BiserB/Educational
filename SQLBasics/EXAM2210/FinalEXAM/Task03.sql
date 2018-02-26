USE ReportService
GO

UPDATE Reports
SET Reports.StatusId = 2
WHERE Reports.StatusId = 1



SELECT * FROM [Status]