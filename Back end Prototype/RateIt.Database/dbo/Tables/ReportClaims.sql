CREATE TABLE [dbo].[ReportClaims](
	Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[CommentId] [bigint] NOT NULL,
	[ByUser] [bigint] NOT NULL, 
    CONSTRAINT [FK_ReportClaims_ToUsers] FOREIGN KEY ([ByUser]) REFERENCES [Users]([Id]), 
    CONSTRAINT [FK_ReportClaims_ToComments] FOREIGN KEY ([CommentId]) REFERENCES [Comments]([Id]),
)
