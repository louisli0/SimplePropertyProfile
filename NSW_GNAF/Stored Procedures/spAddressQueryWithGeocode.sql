CREATE PROCEDURE [dbo].[spAddressWithGeoCode]
	@number int = 0,
	@postcode int
AS
BEGIN
	SELECT lot_number
	, flat_number_prefix
	, flat_number
	, level_number
	, level_number_prefix
	, level_number_suffix
	, number_first
	, STREET.street_name
	, STREET.street_type_code
	, Suburb.locality_name
	, postcode
	, level_geocoded_code
	, latitude
	, longitude
	FROM [dbo].[ADDRESS_DETAIL] as AD
	INNER JOIN [GNAF_Database].[dbo].[ADDRESS_DEFAULT_GEOCODE] AS GEO ON AD.address_detail_pid = GEO.address_detail_pid
	INNER JOIN [dbo].[STREET_LOCALITY] AS STREET ON AD.street_locality_pid = STREET.street_locality_pid
	INNER JOIN [dbo].[LOCALITY] AS Suburb ON AD.locality_pid = Suburb.locality_pid
	WHERE number_first = @number AND postcode = @postcode;
END
