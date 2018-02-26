
CREATE FUNCTION udf_GetRating(@Name VARCHAR(30))
RETURNS VARCHAR(10)
AS
BEGIN
 DECLARE @Rating DECIMAL(10,8) = (SELECT  AVG(F.Rate)
									FROM Products AS P
									JOIN Feedbacks AS F
	                                  ON F.ProductId = P.Id
	                            GROUP BY P.Name
								HAVING P.Name = @Name)
	RETURN (CASE 
				WHEN @Rating < 5 THEN 'Bad'
				WHEN @Rating BETWEEN 5 AND 8 THEN 'Average'
				WHEN @Rating > 8 THEN 'Good'
				ELSE 'No rating'
				END)
END

GO
SELECT TOP 5 Id, Name, dbo.udf_GetRating(Name)
  FROM Products
 ORDER BY Id