CREATE TABLE [dbo].[GeneralNotifications]
(
	[Id] BIGINT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [Text] NVARCHAR(MAX) NOT NULL, 
    [Type] NVARCHAR(100) NOT NULL, 
    [Timestamp] DATETIME NOT NULL DEFAULT GETDATE(), 
    [UserId] BIGINT NOT NULL, 
    [Display] BIT NOT NULL DEFAULT 1, 
    [SystemData] NVARCHAR(MAX) NULL, 
    CONSTRAINT [FK_GeneralNotifications_ToUsers] FOREIGN KEY ([UserId]) REFERENCES [Users]([Id])
)