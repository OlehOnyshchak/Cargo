CREATE TABLE [dbo].[WarehouseItems] (
	[RecordId] INT IDENTITY(0,1) NOT NULL,
	[fReceiptItem] INT NOT NULL,
	[AvailableQuantity] INT NOT NULL,

	CONSTRAINT [PK_Warehouse] PRIMARY KEY CLUSTERED ([RecordId] ASC),
	
	CONSTRAINT [FK_WarehouseItem_ReceiptItems] FOREIGN KEY ([fReceiptItem])
	REFERENCES [dbo].[ReceiptItems](ReceiptItemId) ON DELETE CASCADE,
	
	CONSTRAINT [CHK_WarehouseItem_AvailableQuantity] CHECK ([AvailableQuantity] > 0)
);