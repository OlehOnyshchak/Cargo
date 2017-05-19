CREATE TABLE [dbo].[CurrencyRates] (
	[CurrencyRateId] DATE NOT NULL,
	[EurRate] FLOAT NOT NULL,
	[PlnRate] FLOAT NOT NULL,
	
	CONSTRAINT [PK_CurrencyRate] PRIMARY KEY CLUSTERED ([CurrencyRateId] ASC )
);