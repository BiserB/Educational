USE ReportService
GO

SELECT U.Username,
	   U.Age
FROM Users AS U
ORDER BY U.Age ASC, U.Username DESC

