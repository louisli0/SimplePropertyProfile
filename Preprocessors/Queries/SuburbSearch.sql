SELECT DISTINCT gnaf_locality_pid, SUBURB.locality_pid, locality_name, primary_postcode, postcode
FROM NSW_Property.dbo.LOCALITY as SUBURB
INNER JOIN NSW_Property.dbo.LOCALITY_ALIAS as SUBURB_DATA ON SUBURB.locality_pid = SUBURB_DATA.locality_pid 
WHERE locality_name LIKE '%West%';