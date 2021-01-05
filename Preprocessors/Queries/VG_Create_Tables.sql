--DROP DATABASE NSW_Property_Sales;
CREATE DATABASE NSW_Property_Sales;

CREATE TABLE NSW_Property_Sales.dbo.DistrictCode
(
	DistrictCode int NOT NULL,
	CouncilName varchar(100) NOT NULL
);

CREATE TABLE NSW_Property_Sales.dbo.Prices
(
	DealingNumber varchar(10) NOT NULL,
	PropertyId varchar(10) NOT NULL,
	ContractDate DATE NOT NULL,
	SettlementDate DATE NOT NULL,
	PurchasePrice money NOT NULL,
);

CREATE TABLE NSW_Property_Sales.dbo.Property
(
	DistrictCode varchar(3) NOT NULL,
	RecordDate varchar(16),
	PropertyId varchar(10) NOT NULL,
	StrataLot varchar(5),
	UnitNumber varchar(10),
	HouseNumber varchar(10),
	Street varchar(38),
	Locality varchar(40),
	PostCode int,
	Area DECIMAL(10,3),
	AreaType char,
	DealingNumber varchar(10) NOT NULL
)