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