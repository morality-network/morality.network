CREATE TABLE [dbo].[UserPollingAnswers]
(
	[Id] BIGINT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [UserId] BIGINT NOT NULL, 
    [PollId] BIGINT NOT NULL, 
    [Timestamp] DATETIME NOT NULL DEFAULT GETDATE(), 
    CONSTRAINT [FK_UserPollingAnswers_ToPolls] FOREIGN KEY ([PollId]) REFERENCES [Polls]([Id]), 
    CONSTRAINT [FK_UserPollingAnswers_ToUsers] FOREIGN KEY ([UserId]) REFERENCES [Users]([Id])
)
