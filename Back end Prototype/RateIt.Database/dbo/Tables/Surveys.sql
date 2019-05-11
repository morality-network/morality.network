CREATE TABLE [dbo].[Surveys]
(
	[Id] BIGINT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
	[ContentId] BIGINT NOT NULL,
    [Name] NVARCHAR(500) NOT NULL, 
    [Description] NVARCHAR(MAX) NULL, 
	[AdditionalText] NVARCHAR(MAX) NULL, 
    [Comments] NVARCHAR(50) NULL, 
    [CreatedAt] DATETIME NOT NULL DEFAULT GETDATE(), 
    [CreatedBy] BIGINT NOT NULL, 
    [Active] BIT NOT NULL DEFAULT 1, 
    [ExpiresAt] DATETIME NULL,
    CONSTRAINT [FK_Surveys_ToContents] FOREIGN KEY ([ContentId]) REFERENCES [Contents]([Id]), 
    CONSTRAINT [FK_Surveys_ToUsers] FOREIGN KEY ([CreatedBy]) REFERENCES [Users]([Id]), 
)
