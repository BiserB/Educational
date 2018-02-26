USE Bakery
GO

SELECT CountryName,
	   DisributorName
FROM(
SELECT C.Name AS CountryName,
	   D.Name AS DisributorName,
	   DENSE_RANK() OVER(PARTITION BY C.Name ORDER BY COUNT(I.Name)DESC) AS Grade
 FROM Countries AS C
 JOIN Distributors AS D
 ON D.CountryId = C.Id
 JOIN Ingredients AS I
 ON I.DistributorId = D.Id
 GROUP BY C.Name, D.Name) AS FS
WHERE Grade = 1
ORDER BY CountryName