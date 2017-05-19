CREATE TABLE [dbo].[ExternalSpendings] (
	[ExternalSpendingId] INT IDENTITY(0,1) NOT NULL,
	[fRouteReport] INT NOT NULL,

	[GoodType] INT NOT NULL,
	[Quantity] INT NOT NULL,
	[Price] DOUBLE NOT NULL,
	[GoodName] NVARCHAR(40) NULL,
	
	CONSTRAINT [PK_ExternalSpending] PRIMARY KEY NONCLUSTERED ([ExternalSpendingId] ASC),

	CONSTRAINT [FK_ExternalSpending_RouteReport] FOREIGN KEY ([fRouteReport])
	REFERENCES [dbo].[RouteReports](RouteReportId),
	
	CONSTRAINT [CHK_ExternalSpendings_Quantity] CHECK ([Quantity] > 0),
	CONSTRAINT [CHK_ExternalSpendings_Price] CHECK ([Price] >= 0)
);