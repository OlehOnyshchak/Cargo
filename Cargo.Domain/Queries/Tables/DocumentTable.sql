CREATE TABLE [dbo].[DocumentTemplates] (
	[DocumentTemplateId] DATE NOT NULL,
	[Number] NVARCHAR(16) NOT NULL DEFAULT 1,
	[Template] NVARCHAR(max) NOT NULL,
	
	CONSTRAINT [PK_DocumentTemplate] PRIMARY KEY CLUSTERED ([DocumentTemplateId] ASC )
);