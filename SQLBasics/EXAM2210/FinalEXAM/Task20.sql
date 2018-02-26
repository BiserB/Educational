USE ReportService
GO

WITH cte_StatusType(CatName, Compared)
AS
(
SELECT SS.Name, 
	   Compared = (CASE WHEN SS.Waiting = SS.InProgress THEN 'equal'
						WHEN SS.Waiting > SS.InProgress THEN 'waiting'
						WHEN SS.Waiting < SS.InProgress THEN 'in progress'
					   END)
FROM
	(
	SELECT FS.Name,
		   SUM(FS.Waiting) AS Waiting,
		   SUM(FS.InProgress) AS InProgress
	       FROM(
			SELECT C.Name, 
					Waiting = (CASE WHEN R.StatusId = 1 THEN 1 ELSE 0 END),
					InProgress = (CASE WHEN R.StatusId = 2 THEN 1 ELSE 0 END)
					FROM Categories AS C
					JOIN Reports AS R
					ON R.CategoryId = C.Id
					WHERE R.StatusId IN (1,2)
		     ) AS FS		-- FIRST SELECT
		GROUP BY FS.Name
	)AS SS                  --SECOND SELECT
)



SELECT C.Name AS [Category Name],
	   COUNT(R.StatusId) AS [Reports Number],
	   CTE.Compared AS [Main Status]
FROM Categories AS C
JOIN Reports AS R
ON R.CategoryId = C.Id
JOIN cte_StatusType AS CTE
ON CTE.CatName = C.Name
WHERE R.StatusId IN (1,2)
GROUP BY C.Name, CTE.Compared
ORDER BY [Category Name],[Reports Number],[Main Status] 


go
select * from Status