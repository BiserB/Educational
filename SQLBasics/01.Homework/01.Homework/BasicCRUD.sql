use SoftUni

SELECT * FROM Employees
WHERE NOT (ManagerID = 3 OR ManagerID = 4)

SELECT * FROM Employees
WHERE Salary BETWEEN 20000 AND 30000

SELECT * FROM Employees
WHERE MiddleName IS not NULL
ORDER BY FirstName DESC

USE Geography
GO
CREATE VIEW v_Highest AS
SELECT TOP (1) *
FROM Peaks

SELECT * FROM v_Highest
