
USE WMS
GO

CREATE or alter PROCEDURE usp_PlaceOrder @JobId INT, @SerialNumber VARCHAR(50), @Quantity INT
AS
BEGIN
	DECLARE @PartId INT = (SELECT PartId FROM Parts WHERE Parts.SerialNumber =  @SerialNumber);
	IF NOT EXISTS(SELECT * FROM Jobs WHERE JobId = @JobId)
	 BEGIN
	  RAISERROR ('Job not found!', 16,3)
	  RETURN
	 END
	IF EXISTS(SELECT * FROM Jobs WHERE JobId = @JobId AND Status = 'Finished')
	 BEGIN
	  RAISERROR ('This job is not active!', 16,1)
	  RETURN
	 END
	IF (@Quantity <= 0)
	 BEGIN
	  RAISERROR ('Part quantity must be more than zero!', 16,2)
	  RETURN
	 END
	IF (@PartId IS NULL)
	 BEGIN
	  RAISERROR ('Part not found!', 16,4)
	  RETURN
	 END
	 -------------------------------------------------
	 DECLARE @OrderId INT = (SELECT O.OrderId 
	 FROM Orders AS O
	 JOIN OrderParts AS OP ON OP.OrderId = O.OrderId
	 JOIN Parts AS P ON P.PartId = OP.PartId
	 WHERE O.JobId =@JobId AND P.PartId =@PartId)

-----IF OrderId doesn't exist-------------------
	 
	 IF (@OrderId IS NULL)
	  BEGIN
	    INSERT INTO Orders(JobId,IssueDate,Delivered) VALUES
	    (@JobId, NULL, 0)
	  END
	  INSERT INTO OrderParts(OrderId,PartId, OrderId) VALUES
	  (IDENT_CURRENT('Orders'),@PartId ,@Quantity)
	 ELSE
	  BEGIN
			IF EXISTS(SELECT * FROM Orders WHERE OrderId = @OrderId)
			    AND  (SELECT IssueDate FROM Orders WHERE OrderId = @OrderId) IS NULL
			 BEGIN
			  
			 END
			
	  END

	  END

END

SELECT * FROM Orders
GO

EXEC usp_PlaceOrder 45, '285753A', 1


----------------------TEST

UPDATE OrderParts
			  SET Quantity += @Quantity
			  WHERE PartId = @PartId