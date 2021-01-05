CREATE PROCEDURE [dbo].[spNeighbouringSuburbs]
	@locality varchar(128)
AS
BEGIN
	SELECT DISTINCT LOCALITY.locality_pid, L2.locality_name as neighbouring_suburb, Coord.latitude as sub_lat, Coord.longitude as sub_lng, Coord_N.latitude as n_lat, Coord_N.longitude as n_lng
	FROM NSW_GNAF.dbo.LOCALITY as LOCALITY

	INNER JOIN NSW_GNAF.dbo.LOCALITY_NEIGHBOUR as LOCALITY_N 
		ON LOCALITY.locality_pid = LOCALITY_N.locality_pid

	INNER JOIN NSW_GNAF.dbo.LOCALITY as L2 
		ON LOCALITY_N.neighbour_locality_pid = L2.locality_pid

	INNER JOIN NSW_GNAF.dbo.LOCALITY_POINT as Coord
		ON LOCALITY.locality_pid = Coord.locality_pid

	INNER JOIN NSW_GNAF.dbo.LOCALITY_POINT AS Coord_N
		ON L2.locality_pid = Coord_N.locality_pid
	WHERE LOCALITY.locality_name = @locality;
END