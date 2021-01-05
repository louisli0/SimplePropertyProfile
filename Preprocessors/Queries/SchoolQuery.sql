SELECT building_name, lot_number, number_first, number_first_suffix, number_first_prefix, number_last, number_last_suffix, street_name, street_type_code, locality_name, postcode
FROM NSW_GNAF.dbo.ADDRESS_DETAIL as AD
INNER JOIN NSW_GNAF.dbo.ADDRESS_SITE as ASI on AD.address_site_pid = ASI.address_site_pid
INNER JOIN NSW_GNAF.dbo.STREET_LOCALITY as SL on AD.street_locality_pid = SL.street_locality_pid
INNER JOIN NSW_GNAF.dbo.LOCALITY as L on AD.locality_pid = L.locality_pid
INNER JOIN NSW_GNAF.dbo.STATE as S ON L.state_pid = S.state_pid
WHERE building_name LIKE '%school%' AND L.locality_name = 'Beecroft';