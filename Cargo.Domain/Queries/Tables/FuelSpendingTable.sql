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