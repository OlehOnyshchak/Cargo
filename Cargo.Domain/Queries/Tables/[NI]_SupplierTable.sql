CREATE TABLE [dbo].[Suppliers] (
	[fSupplierId] INT NOT NULL,

	CONSTRAINT [PK_Supplier] PRIMARY KEY CLUSTERED ([fSupplierId] ASC),

	CONSTRAINT [FK_Company] FOREIGN KEY ([fSupplierId])
	REFERENCES [dbo].[Companies](CompanyId)
);