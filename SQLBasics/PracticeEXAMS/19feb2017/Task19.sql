
USE Bakery
GO

CREATE TRIGGER trgAfterDelete ON dbo.Products
INSTEAD OF DELETE
AS
BEGIN
	DECLARE @ProductId INT = (SELECT d.Id FROM deleted AS d)

	DELETE FROM Feedbacks
	WHERE ProductId = @ProductId

	DELETE FROM ProductsIngredients
	WHERE ProductId = @ProductId

	DELETE FROM Products
	WHERE Id = @ProductId

END