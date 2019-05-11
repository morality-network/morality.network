CREATE TABLE [dbo].[Polls]
(
	[Id] BIGINT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
	[SurveyId] BIGINT NULL, 
	[ContentId] BIGINT NOT NULL,
    [Name] NVARCHAR(500) NOT NULL, 
    [Question] NVARCHAR(MAX) NULL, 
    [Comments] NVARCHAR(50) NULL, 
    [CreatedAt] DATETIME NOT NULL DEFAULT GETDATE(), 
    [CreatedBy] BIGINT NOT NULL, 
    [Active] BIT NOT NULL DEFAULT 1, 
    [ExpiresAt] DATETIME NULL,
    CONSTRAINT [FK_Polls_ToContents] FOREIGN KEY ([ContentId]) REFERENCES [Contents]([Id]), 
    CONSTRAINT [FK_Polls_ToUsers] FOREIGN KEY ([CreatedBy]) REFERENCES [Users]([Id]), 
    CONSTRAINT [FK_Polls_ToSurveys] FOREIGN KEY ([SurveyId]) REFERENCES [Surveys]([Id]), 
)
