CREATE VIEW [ApplicationShortView] AS

SELECT
ISNULL(apl.ApplicationId, -1) as ApplicationId, /*IsNull used to help Entity Framework to parse definition*/
NULLIF(veh.VehicleRegistration, '') as VehicleRegistration,
NULLIF(addrSource.City, '') as FromCity,
NULLIF(addrDest.City, '') as ToCity,
NULLIF(apl.Date, '') as StartDate,
NULLIF(apl.fRouteReport, NULL) as fRouteReport

FROM dbo.Applications as apl
JOIN dbo.Addresses as addrSource 
ON apl.fLoadingAddress = addrSource.AddressId

JOIN dbo.Addresses as addrDest 
ON apl.fUnloadingAddress = addrDest.AddressId

JOIN dbo.Vehicles as veh 
ON apl.fVehicle = veh.VehicleId; 