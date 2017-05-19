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