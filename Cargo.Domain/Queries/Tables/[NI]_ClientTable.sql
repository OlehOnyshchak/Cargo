CREATE TABLE [dbo].[Clients] (
	[fClientId] INT NOT NULL,

	CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED ([fClientId] ASC),

	CONSTRAINT [FK_Client_Company] FOREIGN KEY ([fClientId])
	REFERENCES [dbo].[Companies](CompanyId)
);