USE Bakery
GO

SELECT TOP 15 I.Name,
			  I.Description,
			  C.Name
FROM Ingredients AS I
JOIN Countries AS C
ON C.Id = I.OriginCountryId
WHERE(C.Name IN('Bulgaria', 'Greece'))
ORDER BY I.Name ASC, C.Name ASC
