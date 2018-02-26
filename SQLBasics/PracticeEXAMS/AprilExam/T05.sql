USE WMS
GO
SELECT C.FirstName,
	   C.LastName,
	   C.Phone
  FROM Clients AS C
  ORDER BY C.LastName, C.ClientId