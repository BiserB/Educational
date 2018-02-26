SELECT J.Status,
       J.IssueDate
FROM Jobs AS J
WHERE [Status] != ('Finished')
ORDER BY J.IssueDate, J.JobId