﻿CREATE TABLE [dbo].[PaymentTransfer]
(
	[Id] BIGINT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [ExternalTransactionId] NVARCHAR(200) NOT NULL, 
    [Amount] FLOAT NOT NULL, 
    [UserId] BIGINT NOT NULL, 
    [TransferFee] FLOAT NOT NULL,
	[Timestamp] DATETIME NOT NULL DEFAULT GETDATE(), 
    CONSTRAINT [FK_PaymentTransfer_ToUsers] FOREIGN KEY ([UserId]) REFERENCES [Users]([Id])
)
