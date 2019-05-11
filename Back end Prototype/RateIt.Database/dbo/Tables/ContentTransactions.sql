CREATE TABLE [dbo].[ContentTransactions]
(
	[Id] BIGINT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [ContentId] BIGINT NOT NULL, 
    [TransactionHash] NVARCHAR(100) NOT NULL, 
    [Timestamp] DATETIME NULL
)
