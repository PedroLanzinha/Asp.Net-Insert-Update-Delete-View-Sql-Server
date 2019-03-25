CREATE PROC ContactDeleteByID
@ContactID int
AS
	BEGIN
	DELETE FROM Contact 
	WHERE ContactID = @ContactID
	END