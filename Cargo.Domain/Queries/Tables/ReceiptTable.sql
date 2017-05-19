CREATE TABLE [dbo].[Receipts] (
	[ReceiptId] INT IDENTITY(0,1) NOT NULL,
	[fSupplierCompany] INT NOT NULL,
	[Date] DATE NOT NULL DEFAULT CONVERT(DATE, GETDATE())

	CONSTRAINT [PK_Receipt] PRIMARY KEY CLUSTERED ([ReceiptId] ASC),
	
	CONSTRAINT [FK_Receipt_Company_supplier] FOREIGN KEY ([fSupplierCompany])
	REFERENCES [dbo].[Companies](CompanyId)
);