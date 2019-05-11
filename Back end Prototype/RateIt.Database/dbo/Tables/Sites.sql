CREATE TABLE [dbo].[Sites](
	[Id] [bigint] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[AccountId] BIGINT NULL,
    [Timestamp] DATETIME NOT NULL DEFAULT GETDATE(), 
)