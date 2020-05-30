CREATE TABLE [dbo].[UserConfirmations]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [UserId] BIGINT NOT NULL, 
    [Token] NVARCHAR(100) NOT NULL, 
    [DateCreated] DATETIME NOT NULL DEFAULT GETDATE(), 
    [Used] BIT NOT NULL DEFAULT 0, 
    CONSTRAINT [FK_SubscribeConfirm_Subscribe] FOREIGN KEY ([UserId]) REFERENCES [Users]([Id])
)

