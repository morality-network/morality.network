CREATE TABLE [dbo].[InternalTransactions]
(
	[Id] BIGINT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [FromAddress] NVARCHAR(200) NULL,
    [ToAddress] NVARCHAR(200) NOT NULL,
    [Value] decimal NOT NULL, 
    [ExtData] NVARCHAR(1000) NULL, 
    [Timestamp] DATETIME NOT NULL DEFAULT GETDATE(), 
    [FromUserId] BIGINT NULL, 
    [ToUserId] BIGINT NOT NULL, 
    CONSTRAINT [FK_InternalTransactions_ToUser] FOREIGN KEY ([ToUserId]) REFERENCES [Users]([Id]), 
    CONSTRAINT [FK_InternalTransactions_FromUser] FOREIGN KEY ([FromUserId]) REFERENCES [Users]([Id])
)

GO

CREATE INDEX [IX_InternalTransactions_ToUser] ON [dbo].[InternalTransactions] ([ToUserId])

GO

CREATE INDEX [IX_InternalTransactionsFromUser] ON [dbo].[InternalTransactions] ([FromUserId])
