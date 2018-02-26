INSERT INTO Towns([Name]) VALUES  
('Sofia'),
('Plovdiv'),
('Varna'),
('Burgas')
GO

INSERT INTO Departments([Name]) VALUES
('Engineering'), 
('Sales'), 
('Marketing'), 
('Software Development'), 
('Quality Assurance')

GO
INSERT INTO Employees ([FirstName],[MiddleName],[LastName],[JobTitle],[DepartmentId],[HireDate],[Salary]) VALUES
('Ivan', 'Ivanov', 'Ivanov','.NET Developer','Software Development','01/02/2013','3500.00'),
('Petar', 'Petrov', 'Petrov','Senior Engineer','Engineering','02/03/2004','4000.00'),
('Maria', 'Petrova', 'Ivanova','Intern','Quality Assurance','28/08/2016','525.25'),
('Georgi', 'Terziev', 'Ivanov','CEO','Sales','09/12/2007','3000.00'),
('Peter', 'Pan', 'Pan','Intern','Marketing','28/08/2016','599.88')

ALTER TABLE Employees
DROP CONSTRAINT FK__Employees__Depar__2A4B4B5E
ALTER TABLE Employees
ALTER COLUMN DepartmentId NVARCHAR(30)

SELECT [Name] FROM Towns
ORDER BY [Name]
SELECT [Name] FROM Departments
ORDER BY [Name]
SELECT FirstName, LastName, JobTitle, Salary FROM Employees
ORDER BY [Salary] DESC

UPDATE Employees
SET Salary *= 1.1

SELECT Salary FROM Employees
ORDER BY [Salary] DESC

