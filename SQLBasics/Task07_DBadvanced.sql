SELECT  E.FirstName,
		E.LastName,
		P.Name,
		P.StartDate,
		P.EndDate
		FROM Employees AS E
		JOIN EmployeesProjects AS EP
		ON EP.EmployeeID = E.EmployeeID
		JOIN Projects AS P
		ON P.ProjectID = EP.ProjectID
		WHERE (DATEPART(YEAR,P.StartDate) >= 2001) AND
			  (DATEPART(YEAR,P.StartDate) <= 2003)
