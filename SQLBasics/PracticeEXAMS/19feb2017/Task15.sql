USE Bakery
GO

SELECT COUNT(*), D.Name, C.Name 
FROM Ingredients AS I
JOIN Distributors AS D
ON D.Id = I.DistributorId
JOIN Countries AS C
ON C.Id = D.CountryId
GROUP BY D.Name, C.Name


SELECT  CountryName,
	                   DistributorName
FROM (
   SELECT C.Name AS CountryName, 
          D.Name AS DistributorName,
		  DENSE_RANK() OVER(PARTITION BY C.Name ORDER BY COUNT(I.Name)DESC) AS Grade
   FROM Countries AS C
   JOIN Distributors AS D
   ON D.CountryId = C.Id
   JOIN Ingredients AS I
   ON I.DistributorId = D.Id
   GROUP BY C.Name, D.Name
   ) AS FS ----FIRST SELECTION
WHERE Grade = 1
ORDER BY CountryName


--------------------------------

SELECT COUNT(*), D.Name 
FROM Ingredients AS I
JOIN Distributors AS D
ON D.Id = I.DistributorId
GROUP BY D.Name