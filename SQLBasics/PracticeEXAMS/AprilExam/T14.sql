
SELECT J.ModelId,
	   M.Name,
       CONCAT(AVG(DATEDIFF(DAY,J.IssueDate, J.FinishDate)), ' days' )
	   AS [Average Service Time]
FROM Jobs AS J
JOIN Models AS M
ON M.ModelId = J.ModelId
GROUP BY J.ModelId, M.Name
ORDER BY AVG(DATEDIFF(DAY,J.IssueDate, J.FinishDate))