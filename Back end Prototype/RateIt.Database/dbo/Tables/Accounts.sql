CREATE TABLE [dbo].[Accounts](
	[Id] [bigint] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[EthereumAddress] NVARCHAR(42) NOT NULL,
	[Password] NVARCHAR(50) NOT NULL,
	[Salt] NVARCHAR(10) NOT NULL,
	[LastEdit] [datetime] NOT NULL DEFAULT GETDATE(),
	[UserId] [bigint] NOT NULL,
	[Notes] TEXT NULL, 
    [Active] BIT NOT NULL DEFAULT 1, 
    [IsAdmin] BIT NOT NULL DEFAULT 0, 
    CONSTRAINT [FK_Account_ToUsers] FOREIGN KEY ([UserId]) REFERENCES [Users]([Id])
)