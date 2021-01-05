BULK INSERT NSW_PROPERTY_SALES.dbo.DistrictCode
FROM 'C:\Users\User\source\repos\louisli0\SimpleRealEstate\Other\VG_District_psv.psv'
WITH (
	FIRSTROW = 2,
	ROWTERMINATOR = '\n',
	FIELDTERMINATOR = '|'
)


-- Property Sales
SELECT DISTINCT DistrictCode, P.PropertyId, StrataLot, UnitNumber, HouseNumber, Street, Locality, PostCode, PurchasePrice, P.SettlementDate
FROM NSW_Property_Sales.dbo.temp_property AS TP
LEFT JOIN NSW_Property_Sales.dbo.Prices AS P ON TP.DealingNumber = P.DealingNumber AND TP.PropertyId = P.PropertyId

-- Property Sales by Suburb and recent
SELECT DISTINCT DistrictCode, P.PropertyId, StrataLot, UnitNumber, HouseNumber, Street, Locality, PostCode, PurchasePrice, P.ContractDate, P.SettlementDate
FROM NSW_Property_Sales.dbo.temp_property AS TP
LEFT JOIN NSW_Property_Sales.dbo.Prices AS P ON TP.DealingNumber = P.DealingNumber AND TP.PropertyId = P.PropertyId
WHERE P.ContractDate >= '2020' AND Locality = 'west pennant hills';


