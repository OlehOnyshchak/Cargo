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