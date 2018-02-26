USE ReportService
GO


SELECT R.OpenDate,
	   R.Description,
	   U.Email
FROM Reports AS R
JOIN Categories AS C
ON C.Id = R.CategoryId
JOIN Users AS U
ON U.Id = R.UserId
WHERE R.CloseDate IS NULL 
  AND LEN(R.Description) > 20
  AND R.Description LIKE ('%str%')
  AND C.DepartmentId IN (1,4,5)
ORDER BY R.OpenDate, U.Email, R.Id


  SELECT * FROM Departments