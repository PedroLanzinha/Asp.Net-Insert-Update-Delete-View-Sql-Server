CREATE PROC ContactViewByID
@ContactID int
AS
	BEGIN
	SELECT *
	FROM Contact
	WHERE ContactID = @ContactID
	END