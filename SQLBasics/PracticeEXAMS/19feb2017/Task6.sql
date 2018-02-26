USE Bakery
GO

SELECT I.Name,
	   I.Description,
	   I.OriginCountryId
FROM Ingredients AS I
WHERE OriginCountryId IN (1,10,20)
ORDER BY I.Id
