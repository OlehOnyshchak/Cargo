CREATE VIEW [RouteReportShortView] AS

SELECT 
ISNULL(rt.RouteReportId, -1) as RouteReportId, /*IsNull used to help Entity Framework to parse definition*/
NULLIF(veh.VehicleRegistration, '') as VehicleRegistration,
NULLIF(addrSource.City, '') as FromCity,
NULLIF(addrDest.City, '') as ToCity,
NULLIF(rt.StartDate, '') as StartDate

FROM [dbo].[RouteReports] as rt 
JOIN [dbo].[Vehicles] as veh 
ON rt.[fVehicle] = veh.[VehicleId]

CROSS APPLY (
(SELECT TOP 1 *
FROM dbo.Applications as apl
WHERE apl.fRouteReport = rt.RouteReportId) as topApp

JOIN dbo.Addresses as addrSource
ON topApp.[fLoadingAddress] = addrSource.AddressId

JOIN dbo.Addresses as addrDest
ON topApp.[fUnloadingAddress] = addrDest.AddressId
);