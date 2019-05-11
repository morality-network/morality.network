CREATE TABLE [dbo].[Investigations](
	[Id] BIGINT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[CommentId] [bigint] NOT NULL,
	[OverallRemove] [int] NOT NULL DEFAULT 0,
	[OverallKeep] [int] NOT NULL DEFAULT 0,
    [Timestamp] DATETIME NOT NULL DEFAULT GETDATE(), 
    [Resolved] BIT NOT NULL DEFAULT 0, 
    [PassCounter] INT NOT NULL DEFAULT 0, 
    [Removed] BIT NOT NULL DEFAULT 0, 
    CONSTRAINT [FK_Investigations_ToComments] FOREIGN KEY ([CommentId]) REFERENCES [Comments]([Id])
)