CREATE PROCEDURE [dbo].[spSuburbSearch]
	@locality varchar(100)
AS
BEGIN
	set nocount on;
	
	SELECT locality_name
	FROM [NSW_GNAF].[dbo].[Locality]
	WHERE locality_name LIKE  @locality + '%';
END