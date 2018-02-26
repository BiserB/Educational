
USE Bakery
GO

CREATE PROCEDURE usp_SendFeedback 
						@CustomerId INT, 
						@ProductId INT, 
						@Rate DECIMAL(4,2), 
						@Desctiption NVARCHAR(255)
AS
BEGIN
	BEGIN TRANSACTION
	INSERT INTO Feedbacks(CustomerId, ProductId, Rate, Description) VALUES
	(@CustomerId, @ProductId, @Rate, @Desctiption)
	DECLARE @Num INT = (SELECT COUNT(*) FROM Feedbacks AS F WHERE F.CustomerId = @CustomerId AND F.ProductId = @ProductId)
	IF (@Num > 3)
	 BEGIN
	  RAISERROR ('You are limited to only 3 feedbacks per product!', 16,1)
	  RETURN
	 END	
	COMMIT
END

GO
SELECT * FROM Feedbacks

GO

EXEC usp_SendFeedback 1, 5, 7.50, 'Average experience';

SELECT COUNT(*) FROM Feedbacks WHERE CustomerId = 1 AND ProductId = 5;