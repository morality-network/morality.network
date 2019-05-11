CREATE TABLE [dbo].[PaymentChunks]
(
	[Id] BIGINT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [TotalAllowenceInMo] FLOAT NOT NULL DEFAULT 0, 
    [TotalValueOfEachParticipation] FLOAT NOT NULL DEFAULT 0, 
    [TotalAllowenceInMoLeft] FLOAT NOT NULL DEFAULT 0, 
    [CreditWalletId] BIGINT NOT NULL, 
    [IssuedAt] DATETIME NOT NULL DEFAULT GETDATE(), 
    CONSTRAINT [FK_PaymentChunks_ToCreditWallets] FOREIGN KEY ([CreditWalletId]) REFERENCES [CreditWallets]([Id])
)
