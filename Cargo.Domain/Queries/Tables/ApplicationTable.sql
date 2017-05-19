CREATE TABLE [dbo].[Applications] (
	[ApplicationId] INT IDENTITY(0,1) NOT NULL,
	[Compensation] DOUBLE NOT NULL,
	[IsCashCompensation] BIT NOT NULL DEFAULT 0,
	[Date] DATE NOT NULL DEFAULT CONVERT(DATE, GETDATE()),
	[DocumentNumber] NVARCHAR(16) NOT NULL,

	[fClientCompany] INT NOT NULL,
	[fLoadingAddress] INT NOT NULL,
	[fCustomsAddress] INT NULL,
	[fBorderAddress] INT NULL,
	[fClearenceAddress] INT NULL,
	[fUnloadingAddress] INT NOT NULL,

	[fVehicle] INT NOT NULL,
	[fRouteReport] INT NULL,
	[LoadingDate] DATE NULL,
	[UnloadingDate] DATE NULL,
	
	CONSTRAINT [PK_Application] PRIMARY KEY CLUSTERED ([ApplicationId] ASC ),
	
	CONSTRAINT [FK_Application_Address_loading] FOREIGN KEY ([fLoadingAdress])
	REFERENCES [dbo].[Addresses](AddressId),
	
	CONSTRAINT [FK_Application_Address_customs] FOREIGN KEY ([fCustomsAdress])
	REFERENCES [dbo].[Addresses](AddressId),
	
	CONSTRAINT [FK_Application_Address_border] FOREIGN KEY ([fBorderAdress])
	REFERENCES [dbo].[Addresses](AddressId),
	
	CONSTRAINT [FK_Application_Address_clearence] FOREIGN KEY ([fClearenceAdress])
	REFERENCES [dbo].[Addresses](AddressId),
	
	CONSTRAINT [FK_Application_Address_unloading] FOREIGN KEY ([fUnloadingAdress])
	REFERENCES [dbo].[Addresses](AddressId),

	
	CONSTRAINT [FK_Application_RouteReport] FOREIGN KEY ([fRouteReport])
	REFERENCES [dbo].[RouteReports](RouteReportId),

	CONSTRAINT [FK_Application_Vehicle] FOREIGN KEY ([fVehicle])
	REFERENCES [dbo].[Vehicles](VehicleId),

	CONSTRAINT [FK_Application_Company_client] FOREIGN KEY ([fClientCompany])
	REFERENCES [dbo].[Companies](CompanyId)б
	
	CONSTRAINT [CHK_Applications_Compensation] CHECK ([Compensation] >= 0)
);