SELECT DISTINCT TP.DistrictCode, P.PropertyId, StrataLot, UnitNumber, HouseNumber, Street, Locality, PostCode, PurchasePrice, P.DealingNumber, P.SettlementDate
FROM NSW_Property_Sales.dbo.temp_property AS TP
LEFT JOIN NSW_Property_Sales.dbo.Prices AS P ON TP.DealingNumber = P.DealingNumber AND TP.PropertyId = P.PropertyId


SELECT *
FROM NSW_Property_Sales.dbo.Prices

SELECT *
FROM NSW_Property_Sales.dbo.temp_property

DELETE FROM NSW_Property_Sales.dbo.Prices
DELETE FROM NSW_Property_Sales.dbo.temp_property

-- ALTER TABLE NSW_Property_Sales.dbo.temp_property
-- ADD StrataLot varchar(5)