CREATE PROCEDURE [dbo].[spPostcodeQuery]
	@postcode int
AS
BEGIN
	set nocount on;
	SELECT DISTINCT Suburb.locality_pid, locality_name, AD.postcode
	FROM NSW_Property.dbo.LOCALITY AS Suburb
	INNER JOIN NSW_Property.dbo.ADDRESS_DETAIL AS AD ON Suburb.locality_pid = AD.locality_pid
	WHERE postcode = @postcode;

END
