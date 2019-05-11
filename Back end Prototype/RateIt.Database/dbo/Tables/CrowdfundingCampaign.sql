CREATE TABLE [dbo].[CrowdfundingCampaign]
(
	[Id] BIGINT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
	[Name] NVARCHAR(500) NOT NULL, 
    [Description] NVARCHAR(MAX) NOT NULL, 
    [Link] NVARCHAR(500) NULL, 
    [ImageLink] NVARCHAR(500) NULL,
    [TargetAmountMo] FLOAT NOT NULL, 
	[ContentId] BIGINT NOT NULL,
    [StartDate] DATETIME NOT NULL, 
    [EndDate] DATETIME NOT NULL, 
    [CreatedBy] BIGINT NOT NULL, 
    [CreatedAt] DATETIME NOT NULL DEFAULT GETDATE(), 
    [Active] BIT NOT NULL DEFAULT 1, 
    CONSTRAINT [FK_CrowdfundingCampaign_ToUsers] FOREIGN KEY ([CreatedBy]) REFERENCES [Users]([Id]), 
    CONSTRAINT [FK_CrowdfundingCampaign_ToContents] FOREIGN KEY ([ContentId]) REFERENCES [Contents]([Id])
)
