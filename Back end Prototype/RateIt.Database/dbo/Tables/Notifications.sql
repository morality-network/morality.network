CREATE TABLE [dbo].[Notifications](
	[Id] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[SubDirectoryId] [bigint] NOT NULL,
	[UserId] [bigint] NOT NULL,
	[NotificationText] NVARCHAR(500) NULL,
	[Timestamp] [datetime] NOT NULL DEFAULT GETDATE(),
	[NotificationTypeId] [int] NOT NULL, 
    [ContentId] BIGINT NOT NULL, 
    CONSTRAINT [FK_Notifications_ToSubDirectorys] FOREIGN KEY ([SubDirectoryId]) REFERENCES [SubDirectorys]([Id]), 
    CONSTRAINT [FK_Notifications_ToUsers] FOREIGN KEY ([UserId]) REFERENCES [Users]([Id]), 
    CONSTRAINT [FK_Notifications_ToNotificationTypes] FOREIGN KEY ([NotificationTypeId]) REFERENCES [NotificationTypes]([Id]), 
    CONSTRAINT [FK_Notifications_ToContents] FOREIGN KEY ([ContentId]) REFERENCES [Contents]([Id])
)