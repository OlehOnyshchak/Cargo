CREATE TABLE [dbo].[RouteReports] (
	[RouteReportId] INT IDENTITY(0,1) NOT NULL,
	[RoadCredit] DOUBLE NOT NULL,
	[RouteMileage] INT NOT NULL,
	[TaxedMileage] INT NOT NULL,
	[FuelLevelBefore] INT NOT NULL,
	[FuelLevelAfter] INT NOT NULL,
	[StartDate] DATE NOT NULL,
	[BorderCrossingDate] DATE NULL,
	[EndDate] DATE NOT NULL,
	[DriverInterestRate] FLOAT NOT NULL,
	[TotalSpendings] DOUBLE NOT NULL DEFAULT 0,
	
	[fDriver] INT NOT NULL,
	[fVehicle] INT NOT NULL,
	
	CONSTRAINT [PK_Report] PRIMARY KEY CLUSTERED ([RouteReportId] ASC),

	CONSTRAINT [FK_RouteReport_Driver] FOREIGN KEY ([fDriver])
	REFERENCES [dbo].[Drivers](fDriverId),

	CONSTRAINT [FK_RouteReport_Vehicle] FOREIGN KEY ([fVehicle])
	REFERENCES [dbo].[Vehicles](VehicleId),
	
	CONSTRAINT [CHK_RouteReport_RoadCredit] CHECK ([RoadCredit] >= 0),
	CONSTRAINT [CHK_RouteReport_RouteMileage] CHECK ([RouteMileage] >= 0),
	CONSTRAINT [CHK_RouteReport_TaxedMileage] CHECK ([TaxedMileage] >= 0),
	CONSTRAINT [CHK_RouteReport_Mileages] CHECK ([RouteMileage] >= [TaxedMileage]),
	CONSTRAINT [CHK_RouteReport_FuelLevelBefore] CHECK ([FuelLevelBefore] >= 0),
	CONSTRAINT [CHK_RouteReport_FuelLevelAfter] CHECK ([FuelLevelAfter] >= 0),
	CONSTRAINT [CHK_RouteReport_Dates] CHECK ([EndDate] >= [StartDate]),
	CONSTRAINT [CHK_RouteReport_DriverInterestRate] CHECK ([DriverInterestRate] BETWEEN 0.0 AND 1.0),
	CONSTRAINT [CHK_RouteReport_TotalSpendings] CHECK ([TotalSpendings] >= 0)
);