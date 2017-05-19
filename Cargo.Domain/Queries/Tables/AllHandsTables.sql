CREATE TABLE [dbo].[Addresses] (
	[AddressId] INT IDENTITY(0,1) NOT NULL,
	[Country] NVARCHAR(20) NOT NULL,
	[City] NVARCHAR(50) NOT NULL,
	[Street] NVARCHAR(50) NULL,
	[Number] NVARCHAR(10) NULL,
	[PostCode] NVARCHAR(10) NULL, 
	
	CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED ([AddressId] ASC),

	CONSTRAINT [UQ_Address_location] UNIQUE NONCLUSTERED(
        [Country], [City], [Street], [Number]
	)
);

CREATE TABLE [dbo].[Banks] (
	[BankId] INT IDENTITY(0,1) NOT NULL,
	[Name] NVARCHAR(30) NULL,
	[TaxNumber] NVARCHAR(20) NOT NULL,
	
	CONSTRAINT [PK_Bank] PRIMARY KEY CLUSTERED ([BankId] ASC ),

	CONSTRAINT [UQ_Bank_Name] UNIQUE NONCLUSTERED ([Name] ASC)
);

CREATE TABLE [dbo].[CurrencyRates] (
	[CurrencyRateId] DATE NOT NULL,
	[EurRate] FLOAT NOT NULL,
	[PlnRate] FLOAT NOT NULL,
	
	CONSTRAINT [PK_CurrencyRate] PRIMARY KEY CLUSTERED ([CurrencyRateId] ASC )
);

CREATE TABLE [dbo].[Persons] (
	[PersonId] INT IDENTITY(0,1) NOT NULL,
	[Name] NVARCHAR(20) NOT NULL,
	[MiddleName] NVARCHAR(20) NULL,
	[Surname] NVARCHAR(20) NOT NULL 
	
	CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED ([PersonId] ASC )
);

CREATE TABLE [dbo].[Companies] (
	[CompanyId] INT IDENTITY(0,1) NOT NULL,
	[TaxNumber] NVARCHAR(10) NOT NULL,
	[fLegalAddress] INT NOT NULL,
	[fActualAddress] INT NOT NULL,
	[fName] INT NOT NULL,
	[fBank] INT NOT NULL,
	[BankNumber] NVARCHAR(30) NOT NULL,
	[LogicalType] INT NOT NULL,
	[Phone] NVARCHAR(15) NULL,
	[Email] NVARCHAR(55) NULL,

	CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED ([CompanyId] ASC),

	CONSTRAINT [FK_Companies_Address_legal] FOREIGN KEY ([fLegalAddress])
	REFERENCES [dbo].[Addresses](AddressId),

	CONSTRAINT [FK_Companies_Address_actual] FOREIGN KEY ([fActualAddress])
	REFERENCES [dbo].[Addresses](AddressId),

	CONSTRAINT [FK_Companies_Person] FOREIGN KEY ([fName])
	REFERENCES [dbo].[Persons](PersonId),

	CONSTRAINT [FK_Companies_Bank] FOREIGN KEY ([fBank])
	REFERENCES [dbo].[Banks](BankId),

	CONSTRAINT [UQ_Companies_TaxNumber] UNIQUE NONCLUSTERED ([TaxNumber] ASC)
);

CREATE TABLE [dbo].[DocumentTemplates] (
	[DocumentTemplateId] INT IDENTITY(0,1) NOT NULL,
	[Number] NVARCHAR(16) NOT NULL DEFAULT 1,
	[Template] NVARCHAR(max) NOT NULL,
	
	CONSTRAINT [PK_DocumentTemplate] PRIMARY KEY CLUSTERED ([DocumentTemplateId] ASC )
);

CREATE TABLE [dbo].[Drivers] (
	[fDriverId] INT NOT NULL,
	[PassportNum] NVARCHAR(8) NOT NULL,
	[InterestRate] FLOAT NOT NULL,
	
	CONSTRAINT [PK_Driver] PRIMARY KEY CLUSTERED ([fDriverId] ASC ),
	
	CONSTRAINT [FK_Driver_Person] FOREIGN KEY ([fDriverId])
	REFERENCES [dbo].[Persons](PersonId),

	CONSTRAINT [UQ_Driver_Passport] UNIQUE NONCLUSTERED ([PassportNum] ASC),
	
	CONSTRAINT [CHK_Driver_InterestRate] CHECK ([InterestRate] BETWEEN 0.0 AND 1.0)
);

CREATE TABLE [dbo].[Vehicles] (
	[VehicleId] INT IDENTITY(0,1) NOT NULL,
	[VehicleRegistration] NVARCHAR(8) NOT NULL,
	[TrailerRegistration] NVARCHAR(8) NOT NULL,
	[VehicleBrand] NVARCHAR(20) NOT NULL,
	
	CONSTRAINT [PK_Vehicle] PRIMARY KEY CLUSTERED ([VehicleId] ASC ),

	CONSTRAINT [UQ_Vehicle_VehicleRegistration] UNIQUE NONCLUSTERED ([VehicleRegistration] ASC),
	CONSTRAINT [UQ_Vehicle_TrailerRegistration] UNIQUE NONCLUSTERED ([TrailerRegistration] ASC)
);

CREATE TABLE [dbo].[Receipts] (
	[ReceiptId] INT IDENTITY(0,1) NOT NULL,
	[fSupplierCompany] INT NOT NULL,
	[Date] DATE NOT NULL DEFAULT CONVERT(DATE, GETDATE())

	CONSTRAINT [PK_Receipt] PRIMARY KEY CLUSTERED ([ReceiptId] ASC),
	
	CONSTRAINT [FK_Receipt_Company_supplier] FOREIGN KEY ([fSupplierCompany])
	REFERENCES [dbo].[Companies](CompanyId)
);

CREATE TABLE [dbo].[ReceiptItems] (
	[ReceiptItemId] INT IDENTITY(0,1) NOT NULL,
	[fReceipt] INT NOT NULL,
	[Producer] NVARCHAR(20) NOT NULL,
	[Quantity] INT NOT NULL,
	[Price] FLOAT NOT NULL,
	[GoodType] INT NOT NULL DEFAULT 0,
	[GoodName] NVARCHAR(40) NULL,
	
	CONSTRAINT [PK_ReceiptItem] PRIMARY KEY CLUSTERED ([ReceiptItemId] ASC ),

	CONSTRAINT [FK_ReceiptItem_Receipt] FOREIGN KEY ([fReceipt])
	REFERENCES [dbo].[Receipts](ReceiptId) ON DELETE CASCADE,
	
	CONSTRAINT [CHK_ReceiptItem_Quantity] CHECK ([Quantity] > 0),
	CONSTRAINT [CHK_ReceiptItem_Price] CHECK ([Price] >= 0)
);

CREATE TABLE [dbo].[RouteReports] (
	[RouteReportId] INT IDENTITY(0,1) NOT NULL,
	[RoadCredit] FLOAT NOT NULL,
	[RouteMileage] INT NOT NULL,
	[TaxedMileage] INT NOT NULL,
	[FuelLevelBefore] INT NOT NULL,
	[FuelLevelAfter] INT NOT NULL,
	[StartDate] DATE NOT NULL,
	[BorderCrossingDate] DATE NULL,
	[EndDate] DATE NOT NULL,
	[DriverInterestRate] FLOAT NOT NULL,
	[TotalSpendings] FLOAT NOT NULL DEFAULT 0,
	
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

CREATE TABLE [dbo].[ExternalSpendings] (
	[ExternalSpendingId] INT IDENTITY(0,1) NOT NULL,
	[fRouteReport] INT NOT NULL,

	[GoodType] INT NOT NULL,
	[Quantity] INT NOT NULL,
	[Price] FLOAT NOT NULL,
	[GoodName] NVARCHAR(40) NULL,
	
	CONSTRAINT [PK_ExternalSpending] PRIMARY KEY NONCLUSTERED ([ExternalSpendingId] ASC),

	CONSTRAINT [FK_ExternalSpending_RouteReport] FOREIGN KEY ([fRouteReport])
	REFERENCES [dbo].[RouteReports](RouteReportId),
	
	CONSTRAINT [CHK_ExternalSpendings_Quantity] CHECK ([Quantity] > 0),
	CONSTRAINT [CHK_ExternalSpendings_Price] CHECK ([Price] >= 0)
);

CREATE TABLE [dbo].[ServiceSpendings] (
	[ServiceSpendingId] INT IDENTITY(0,1) NOT NULL,
	[fReceiptItem] INT NOT NULL,
	[fVehicle] INT NOT NULL,
	[SpentQuantity] INT NOT NULL,

	CONSTRAINT [PK_ServiceSpendings] PRIMARY KEY CLUSTERED ([ServiceSpendingId] ASC),
	
	CONSTRAINT [FK_ServiceSpendings_ReceiptItem] FOREIGN KEY ([fReceiptItem])
	REFERENCES [dbo].[ReceiptItems](ReceiptItemId) ON DELETE CASCADE,

	CONSTRAINT [FK_ServiceSpendings_Vehicle] FOREIGN KEY ([fVehicle])
	REFERENCES [dbo].[Vehicles](VehicleId) ON DELETE CASCADE,
	
	CONSTRAINT [CHK_ServiceSpendings_SpentQuantity] CHECK ([SpentQuantity] > 0)
);

CREATE TABLE [dbo].[WarehouseItems] (
	[fWarehouseItemId] INT NOT NULL,
	[AvailableQuantity] INT NOT NULL,

	CONSTRAINT [PK_Warehouse] PRIMARY KEY CLUSTERED ([fWarehouseItemId] ASC),
	
	CONSTRAINT [FK_WarehouseItem_ReceiptItems] FOREIGN KEY ([fWarehouseItemId])
	REFERENCES [dbo].[ReceiptItems](ReceiptItemId) ON DELETE CASCADE,
	
	CONSTRAINT [CHK_WarehouseItem_AvailableQuantity] CHECK ([AvailableQuantity] > 0)
);

CREATE TABLE [dbo].[FuelSpendings] (
	[FuelSpendingId] INT IDENTITY(0,1) NOT NULL,
	[fReceiptItem] INT NOT NULL,
	[fRouteReport] INT NULL,
	[SpentQuantity] INT NOT NULL,

	CONSTRAINT [PK_FuelSpendings] PRIMARY KEY CLUSTERED ([FuelSpendingId] ASC),
	
	CONSTRAINT [FK_FuelSpendings_ReceiptItem] FOREIGN KEY ([fReceiptItem])
	REFERENCES [dbo].[ReceiptItems](ReceiptItemId),

	CONSTRAINT [FK_FuelSpendings_RouteReport] FOREIGN KEY ([fRouteReport])
	REFERENCES [dbo].[RouteReports](RouteReportId),
	
	CONSTRAINT [CHK_FuelSpendings_SpentQuantity] CHECK ([SpentQuantity] > 0)
);

CREATE TABLE [dbo].[Applications] (
	[ApplicationId] INT IDENTITY(0,1) NOT NULL,
	[Compensation] FLOAT NOT NULL,
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
	
	CONSTRAINT [FK_Application_Address_loading] FOREIGN KEY ([fLoadingAddress])
	REFERENCES [dbo].[Addresses](AddressId),
	
	CONSTRAINT [FK_Application_Address_customs] FOREIGN KEY ([fCustomsAddress])
	REFERENCES [dbo].[Addresses](AddressId),
	
	CONSTRAINT [FK_Application_Address_border] FOREIGN KEY ([fBorderAddress])
	REFERENCES [dbo].[Addresses](AddressId),
	
	CONSTRAINT [FK_Application_Address_clearence] FOREIGN KEY ([fClearenceAddress])
	REFERENCES [dbo].[Addresses](AddressId),
	
	CONSTRAINT [FK_Application_Address_unloading] FOREIGN KEY ([fUnloadingAddress])
	REFERENCES [dbo].[Addresses](AddressId),

	
	CONSTRAINT [FK_Application_RouteReport] FOREIGN KEY ([fRouteReport])
	REFERENCES [dbo].[RouteReports](RouteReportId),

	CONSTRAINT [FK_Application_Vehicle] FOREIGN KEY ([fVehicle])
	REFERENCES [dbo].[Vehicles](VehicleId),

	CONSTRAINT [FK_Application_Company_client] FOREIGN KEY ([fClientCompany])
	REFERENCES [dbo].[Companies](CompanyId),
	
	CONSTRAINT [CHK_Applications_Compensation] CHECK ([Compensation] >= 0)
);