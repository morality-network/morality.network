CREATE TABLE [dbo].[Transactions](
	[Id] [bigint] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[AddressFrom] NVARCHAR(42) NOT NULL,
	[AddressTo] NVARCHAR(42) NOT NULL,
	[Fee] FLOAT NOT NULL,
	[Amount] FLOAT NOT NULL,
	[CurrencyId] BIGINT NOT NULL,
	[TransactionHash] NVARCHAR(200) NOT NULL,
	[UserFrom] [bigint] NOT NULL,
	[UserTo] [bigint] NOT NULL,
	[Notes] NVARCHAR(1000) NULL,
	[Confirmed] [bit] NOT NULL DEFAULT 0,
	[Timestamp] [datetime] NOT NULL DEFAULT GETDATE(), 
    [BlockNumber] BIGINT NOT NULL, 
    CONSTRAINT [FK_Transactions_ToUsersFrom] FOREIGN KEY ([UserFrom]) REFERENCES [Users]([Id]),
	CONSTRAINT [FK_Transactions_ToUsersTo] FOREIGN KEY ([UserTo]) REFERENCES [Users]([Id])
)