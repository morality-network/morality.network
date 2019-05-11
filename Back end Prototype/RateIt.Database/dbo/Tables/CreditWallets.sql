CREATE TABLE [dbo].[CreditWallets]
(
	[Id] BIGINT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [CurrentAmount] FLOAT NOT NULL DEFAULT 0, 
    [LastUpdated] DATETIME NOT NULL DEFAULT GETDATE(), 
    [Active] BIT NOT NULL DEFAULT 1, 
    [AccountId] BIGINT NOT NULL, 
    CONSTRAINT [FK_CreditWallets_ToUsers] FOREIGN KEY ([AccountId]) REFERENCES [Accounts]([Id])
)
