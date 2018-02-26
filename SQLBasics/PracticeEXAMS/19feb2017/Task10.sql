USE Bakery
GO
         SELECT CONCAT(C.FirstName,' ', C.LastName) AS CustomerName,
	            C.PhoneNumber,
				C.Gender
           FROM Customers AS C
LEFT OUTER JOIN Feedbacks AS F
             ON (F.CustomerId = C.Id)
		  WHERE F.Id IS NULL
		  ORDER BY C.Id

-----------------------------------------------------

