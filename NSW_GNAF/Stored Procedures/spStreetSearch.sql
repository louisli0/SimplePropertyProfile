CREATE PROCEDURE [dbo].[spStreetSearch]
	@street varchar(38),
	@locality varchar(40)
AS
BEGIN
	SELECT TOP 5 Street_name, street_type_code, locality_name
	FROM NSW_Property.dbo.STREET_LOCALITY AS SL
	INNER JOIN NSW_Property.dbo.LOCALITY AS L ON SL.locality_pid = L.locality_pid
	WHERE street_name LIKE (@street +'%') OR locality_name LIKE (@locality + '%');
END