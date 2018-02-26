
SELECT C.FirstName,
       C.Age,
	   C.PhoneNumber
FROM Customers AS C
JOIN Countries AS Co
ON Co.Id = C.CountryId
WHERE C.Age >= 21   AND (C.FirstName LIKE '%an%' OR C.PhoneNumber LIKE '%38')
  AND Co.Name != 'Greece'
ORDER BY C.FirstName, C.Age


