USE Geography
GO
SELECT [CountryName] AS [Country], [CurrencyCode]
INTO Valuta
FROM Countries
WHERE [CurrencyCode] LIKE 'EU_'
OR [CurrencyCode] = 'USD'


SELECT * FROM Valuta

DELETE FROM Valuta
WHERE CurrencyCode = 'USD'

DROP TABLE Valuta

SELECT [Country] FROM Valuta
UNION ALL INTO Valuta
SELECT [CurrencyCode] FROM Countries

