CREATE TABLE [dbo].[Companies] (
	[CompanyId] INT IDENTITY(0,1) NOT NULL,
	[TaxNumber] NVARCHAR(10) NOT NULL,
	[fLegalAddress] INT NOT NULL,
	[fActualAddress] INT NOT NULL,
	[fName] INT NOT NULL,
	[fBank] INT NOT NULL,
	[BankNumber] NVARCHAR(30) NOT NULL,
	[LogicalType] INT NOT NULL,

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