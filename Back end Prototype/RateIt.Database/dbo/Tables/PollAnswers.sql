CREATE TABLE [dbo].[PollAnswers]
(
	[Id] BIGINT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [Text] NVARCHAR(500) NOT NULL, 
    [Comments] NVARCHAR(500) NOT NULL, 
    [PollId] BIGINT NOT NULL, 
    CONSTRAINT [FK_PollAnswers_ToPolls] FOREIGN KEY ([PollId]) REFERENCES [Polls]([Id])
)
