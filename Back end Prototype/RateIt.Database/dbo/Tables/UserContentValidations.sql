CREATE TABLE [dbo].[UserContentValidations]
(
	[Id] BIGINT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [UserId] BIGINT NOT NULL, 
    [ContentId] BIGINT NOT NULL, 
    [ShouldBePersisted] BIT NOT NULL DEFAULT 0, 
    [Timestamp] DATETIME NOT NULL DEFAULT GETDATE(), 
    [Active] BIT NOT NULL DEFAULT 1, 
    CONSTRAINT [FK_UserContentValidations_ToUsers] FOREIGN KEY ([UserId]) REFERENCES [Users]([Id]), 
    CONSTRAINT [FK_UserContentValidations_ToContents] FOREIGN KEY ([ContentId]) REFERENCES [Contents]([Id])
)
