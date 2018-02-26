USE ReportService
GO

SELECT U.Username
  FROM Users AS U
  JOIN Reports AS R
    ON R.UserId = U.Id
 WHERE U.Username LIKE '[0-9]%' AND CONCAT(LEFT(U.Username, 1), '' )= CONCAT(R.CategoryId,'')
    OR U.Username LIKE '%[0-9]' AND CONCAT(RIGHT(U.Username, 1),'' )= CONCAT(R.CategoryId,'')
ORDER BY U.Username