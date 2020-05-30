CREATE TABLE [dbo].[CreditWallets]
(
	[Id] BIGINT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [CurrentAmount] DECIMAL(18, 8) NOT NULL DEFAULT 0, 
    [LastUpdated] DATETIME NOT NULL DEFAULT GETDATE(), 
    [Active] BIT NOT NULL DEFAULT 1, 
    [UserId] BIGINT NOT NULL, 
    [CurrencyId] BIGINT NOT NULL, 
    CONSTRAINT [FK_CreditWallets_ToUsers] FOREIGN KEY ([UserId]) REFERENCES [Users]([Id]), 
    CONSTRAINT [FK_CreditWallets_ToCurrency] FOREIGN KEY (CurrencyId) REFERENCES [Currencys]([Id])
)
