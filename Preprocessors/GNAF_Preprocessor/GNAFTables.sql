CREATE TABLE LocalityDetails (
    LocalityPID varchar(15) NOT NULL
    , Name varchar(100) NOT NULL
    , Longitude numeric(11,8)
    , Latitude numeric(10,8)
    , PostCode varchar(4) NOT NULL
)

CREATE TABLE StreetLocalityDetails (
    street_locality_pid  varchar(15)
    , [Name] varchar(100) NOT NULL
    , [Type] varchar(15)  NOT NULL
    , SuffixCode varchar(15) NOT NULL
    , LocalityPID varchar(15) NOT NULL
    , Longitude numeric(11,8)
    , Latitude numeric(10,8)
)

CREATE TABLE AddressData (
    addressDetailPid varchar(15) NOT NULL,
    locality_pid varchar(15) NOT NULL,
    lot_number_prefix varchar(2),
    lot_number varchar(5),
    lot_number_suffix varchar(2),
    flat_type_code varchar(7),
    flat_number_prefix varchar(2),
    flat_number numeric(5),
    flat_number_suffix varchar(2),
    level_type_code varchar(4),
    level_number_prefix varchar(2),
    level_number numeric(3),
    level_number_suffix varchar(2),
    number_first_prefix varchar(3),
    number_first numeric(6),
    number_first_suffix varchar(2),
    number_last_prefix varchar(3),
    number_last numeric(6),
    number_last_suffix varchar(2),
    postcode varchar(4),
    street_locality_pid varchar(15),
    longitude numeric(11,8),
    latitude numeric(10,8)
)