BULK INSERT NSW_GNAF.dbo.ADDRESS_ALIAS
FROM 'C:\Users\User\Desktop\aug20_gnaf_pipeseparatedvalue_gda2020\G-NAF\G-NAF AUGUST 2020\Standard\NSW_ADDRESS_ALIAS_psv.psv'
WITH (
    FIRSTROW = 2,
    FIELDTERMINATOR = '|',
    ROWTERMINATOR = '\n'
);

BULK INSERT NSW_GNAF.dbo.ADDRESS_DEFAULT_GEOCODE
FROM 'C:\Users\User\Desktop\aug20_gnaf_pipeseparatedvalue_gda2020\G-NAF\G-NAF AUGUST 2020\Standard\NSW_ADDRESS_DEFAULT_GEOCODE_psv.psv'
WITH (
    FIRSTROW = 2,
    FIELDTERMINATOR = '|',
    ROWTERMINATOR = '\n'
);

BULK INSERT NSW_GNAF.dbo.ADDRESS_DETAIL
FROM 'C:\Users\User\Desktop\aug20_gnaf_pipeseparatedvalue_gda2020\G-NAF\G-NAF AUGUST 2020\Standard\NSW_ADDRESS_DETAIL_psv.psv'
WITH (
    FIRSTROW = 2,
    FIELDTERMINATOR = '|',
    ROWTERMINATOR = '\n'
);

BULK INSERT NSW_GNAF.dbo.ADDRESS_FEATURE
FROM 'C:\Users\User\Desktop\aug20_gnaf_pipeseparatedvalue_gda2020\G-NAF\G-NAF AUGUST 2020\Standard\NSW_ADDRESS_FEATURE_psv.psv'
WITH (
    FIRSTROW = 2,
    FIELDTERMINATOR = '|',
    ROWTERMINATOR = '\n'
);

BULK INSERT NSW_GNAF.dbo.ADDRESS_MESH_BLOCK_2011
FROM 'C:\Users\User\Desktop\aug20_gnaf_pipeseparatedvalue_gda2020\G-NAF\G-NAF AUGUST 2020\Standard\NSW_ADDRESS_MESH_BLOCK_2011_psv.psv'
WITH (
    FIRSTROW = 2,
    FIELDTERMINATOR = '|',
    ROWTERMINATOR = '\n'
);

BULK INSERT NSW_GNAF.dbo.ADDRESS_MESH_BLOCK_2016
FROM 'C:\Users\User\Desktop\aug20_gnaf_pipeseparatedvalue_gda2020\G-NAF\G-NAF AUGUST 2020\Standard\NSW_ADDRESS_MESH_BLOCK_2016_psv.psv'
WITH (
    FIRSTROW = 2,
    FIELDTERMINATOR = '|',
    ROWTERMINATOR = '\n'
);

BULK INSERT NSW_GNAF.dbo.ADDRESS_SITE_GEOCODE
FROM 'C:\Users\User\Desktop\aug20_gnaf_pipeseparatedvalue_gda2020\G-NAF\G-NAF AUGUST 2020\Standard\NSW_ADDRESS_SITE_GEOCODE_psv.psv'
WITH (
    FIRSTROW = 2,
    FIELDTERMINATOR = '|',
    ROWTERMINATOR = '\n'
);

BULK INSERT NSW_GNAF.dbo.ADDRESS_SITE
FROM 'C:\Users\User\Desktop\aug20_gnaf_pipeseparatedvalue_gda2020\G-NAF\G-NAF AUGUST 2020\Standard\NSW_ADDRESS_SITE_psv.psv'
WITH (
    FIRSTROW = 2,
    FIELDTERMINATOR = '|',
    ROWTERMINATOR = '\n'
);

BULK INSERT NSW_GNAF.dbo.LOCALITY_NEIGHBOUR
FROM 'C:\Users\User\Desktop\aug20_gnaf_pipeseparatedvalue_gda2020\G-NAF\G-NAF AUGUST 2020\Standard\NSW_LOCALITY_NEIGHBOUR_psv.psv'
WITH (
    FIRSTROW = 2,
    FIELDTERMINATOR = '|',
    ROWTERMINATOR = '\n'
);

BULK INSERT NSW_GNAF.dbo.LOCALITY_ALIAS
FROM 'C:\Users\User\Desktop\aug20_gnaf_pipeseparatedvalue_gda2020\G-NAF\G-NAF AUGUST 2020\Standard\NSW_LOCALITY_ALIAS_psv.psv'
WITH (
    FIRSTROW = 2,
    FIELDTERMINATOR = '|',
    ROWTERMINATOR = '\n'
);

BULK INSERT NSW_GNAF.dbo.LOCALITY_POINT
FROM 'C:\Users\User\Desktop\aug20_gnaf_pipeseparatedvalue_gda2020\G-NAF\G-NAF AUGUST 2020\Standard\NSW_LOCALITY_POINT_psv.psv'
WITH (
    FIRSTROW = 2,
    FIELDTERMINATOR = '|',
    ROWTERMINATOR = '\n'
);

BULK INSERT NSW_GNAF.dbo.LOCALITY
FROM 'C:\Users\User\Desktop\aug20_gnaf_pipeseparatedvalue_gda2020\G-NAF\G-NAF AUGUST 2020\Standard\NSW_LOCALITY_psv.psv'
WITH (
    FIRSTROW = 2,
    FIELDTERMINATOR = '|',
    ROWTERMINATOR = '\n'
);

BULK INSERT NSW_GNAF.dbo.MB_2011
FROM 'C:\Users\User\Desktop\aug20_gnaf_pipeseparatedvalue_gda2020\G-NAF\G-NAF AUGUST 2020\Standard\NSW_MB_2011_psv.psv'
WITH (
    FIRSTROW = 2,
    FIELDTERMINATOR = '|',
    ROWTERMINATOR = '\n'
);

BULK INSERT NSW_GNAF.dbo.MB_2016
FROM 'C:\Users\User\Desktop\aug20_gnaf_pipeseparatedvalue_gda2020\G-NAF\G-NAF AUGUST 2020\Standard\NSW_MB_2016_psv.psv'
WITH (
    FIRSTROW = 2,
    FIELDTERMINATOR = '|',
    ROWTERMINATOR = '\n'
);

BULK INSERT NSW_GNAF.dbo.PRIMARY_SECONDARY
FROM 'C:\Users\User\Desktop\aug20_gnaf_pipeseparatedvalue_gda2020\G-NAF\G-NAF AUGUST 2020\Standard\NSW_PRIMARY_SECONDARY_psv.psv'
WITH (
    FIRSTROW = 2,
    FIELDTERMINATOR = '|',
    ROWTERMINATOR = '\n'
);

BULK INSERT NSW_GNAF.dbo.STATE
FROM 'C:\Users\User\Desktop\aug20_gnaf_pipeseparatedvalue_gda2020\G-NAF\G-NAF AUGUST 2020\Standard\NSW_STATE_psv.psv'
WITH (
    FIRSTROW = 2,
    FIELDTERMINATOR = '|',
    ROWTERMINATOR = '\n'
);

BULK INSERT NSW_GNAF.dbo.STREET_LOCALITY_ALIAS
FROM 'C:\Users\User\Desktop\aug20_gnaf_pipeseparatedvalue_gda2020\G-NAF\G-NAF AUGUST 2020\Standard\NSW_STREET_LOCALITY_ALIAS_psv.psv'
WITH (
    FIRSTROW = 2,
    FIELDTERMINATOR = '|',
    ROWTERMINATOR = '\n'
);

BULK INSERT NSW_GNAF.dbo.STREET_LOCALITY_POINT
FROM 'C:\Users\User\Desktop\aug20_gnaf_pipeseparatedvalue_gda2020\G-NAF\G-NAF AUGUST 2020\Standard\NSW_STREET_LOCALITY_POINT_psv.psv'
WITH (
    FIRSTROW = 2,
    FIELDTERMINATOR = '|',
    ROWTERMINATOR = '\n'
);

BULK INSERT NSW_GNAF.dbo.STREET_LOCALITY
FROM 'C:\Users\User\Desktop\aug20_gnaf_pipeseparatedvalue_gda2020\G-NAF\G-NAF AUGUST 2020\Standard\NSW_STREET_LOCALITY_psv.psv'
WITH (
    FIRSTROW = 2,
    FIELDTERMINATOR = '|',
    ROWTERMINATOR = '\n'
);

