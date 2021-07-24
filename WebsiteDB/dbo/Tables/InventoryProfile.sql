CREATE TABLE [dbo].[InventoryProfile]
(
	[ItemId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ItemName] VARCHAR(50) NULL, 
    [ItemDescription] VARCHAR(100) NULL, 
    [ItemManufactor] VARCHAR(50) NULL, 
    [ItemQty] INT NULL, 
    [ItemRetailPrice] FLOAT NULL, 
    [UserCredentialsID] INT NOT NULL
)
