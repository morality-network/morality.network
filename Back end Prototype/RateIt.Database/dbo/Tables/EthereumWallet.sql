CREATE TABLE [dbo].[EthereumWallet]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [EthereumAddress] NVARCHAR(200) NOT NULL, 
    [Secret] NVARCHAR(MAX) NOT NULL, 
    [Salt] NVARCHAR(50) NOT NULL, 
    [DateCreated] DATETIME NOT NULL DEFAULT GETDATE(), 
    [ImportedFromPresale] BIT NOT NULL, 
    [UserId] BIGINT NOT NULL, 
    CONSTRAINT [FK_EthereumWallet_ToUser] FOREIGN KEY ([UserId]) REFERENCES [Users]([Id])
)
