CREATE TABLE [dbo].[PublisherChannel]
(
	[Id] BIGINT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [AccountId] BIGINT NOT NULL, 
    [Name] NVARCHAR(200) NOT NULL, 
    [Description] NVARCHAR(2000) NULL, 
    [UniqueDomain] NVARCHAR(200) NOT NULL, 
    [Tips] FLOAT NOT NULL DEFAULT 0, 
    [PersonalWebsiteUrl] NVARCHAR(1000) NULL, 
    [Rating] INT NOT NULL DEFAULT 0, 
    [LogoUrl] NVARCHAR(1000) NULL, 
    CONSTRAINT [FK_PublisherChannel_ToAccounts] FOREIGN KEY ([AccountId]) REFERENCES [Accounts]([Id])
)
