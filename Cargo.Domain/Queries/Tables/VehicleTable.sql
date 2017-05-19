CREATE TABLE [dbo].[Vehicles] (
	[VehicleId] INT IDENTITY(0,1) NOT NULL,
	[VehicleRegistration] NVARCHAR(8) NOT NULL,
	[TrailerRegistration] NVARCHAR(8) NOT NULL,
	[VehicleBrand] NVARCHAR(20) NOT NULL,
	
	CONSTRAINT [PK_Vehicle] PRIMARY KEY CLUSTERED ([VehicleId] ASC ),

	CONSTRAINT [UQ_Vehicle_VehicleRegistration] UNIQUE NONCLUSTERED ([VehicleRegistration] ASC),
	CONSTRAINT [UQ_Vehicle_TrailerRegistration] UNIQUE NONCLUSTERED ([TrailerRegistration] ASC)
);