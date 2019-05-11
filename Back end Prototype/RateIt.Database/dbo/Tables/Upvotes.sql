CREATE TABLE [dbo].[Upvotes](
	[Id] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[UserId] [bigint] NOT NULL,
	[CommentId] [bigint] NOT NULL,
	[Vote] [bit] NOT NULL, 
    CONSTRAINT [FK_Upvotes_ToUsers] FOREIGN KEY ([UserId]) REFERENCES [Users]([Id]),
	CONSTRAINT [FK_Upvotes_ToComments] FOREIGN KEY ([CommentId]) REFERENCES [Comments]([Id])
)