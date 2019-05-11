CREATE TABLE [dbo].[CreditTransactions]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [FromUserId] BIGINT NOT NULL, 
    [ToUserId] BIGINT NOT NULL, 
    [Amount] FLOAT NOT NULL, 
    [Timestamp] DATETIME NOT NULL DEFAULT GETDATE(), 
    [AdminNotes] NVARCHAR(500) NULL, 
    [Notes] NCHAR(500) NULL, 
    [LinkedId] BIGINT NULL, 
    [PaymentTypeId] BIGINT NOT NULL, 
    CONSTRAINT [FK_CreditTransactions_ToUser] FOREIGN KEY ([ToUserId]) REFERENCES [Users]([Id]), 
    CONSTRAINT [FK_CreditTransactions_FromUser] FOREIGN KEY ([FromUserId]) REFERENCES [Users]([Id]), 
    CONSTRAINT [FK_CreditTransactions_ToPaymentTypes] FOREIGN KEY ([PaymentTypeId]) REFERENCES [PaymentTypes]([Id])
)
