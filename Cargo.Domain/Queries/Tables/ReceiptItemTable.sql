CREATE TABLE [dbo].[ReceiptItems] (
	[ReceiptItemId] INT IDENTITY(0,1) NOT NULL,
	[fReceipt] INT NOT NULL,
	[Producer] NVARCHAR(20) NOT NULL,
	[Quantity] INT NOT NULL,
	[Price] FLOAT NOT NULL,
	[GoodType] INT NOT NULL DEFAULT 0,
	[GoodName] NVARCHAR(40) NULL 
	
	CONSTRAINT [PK_ReceiptItem] PRIMARY KEY CLUSTERED ([ReceiptItemId] ASC ),

	CONSTRAINT [FK_ReceiptItem_Receipt] FOREIGN KEY ([fReceipt])
	REFERENCES [dbo].[Receipts](ReceiptId) ON DELETE CASCADE,
	
	CONSTRAINT [CHK_ReceiptItem_Quantity] CHECK ([Quantity] > 0),
	CONSTRAINT [CHK_ReceiptItem_Price] CHECK ([Price] >= 0)
);