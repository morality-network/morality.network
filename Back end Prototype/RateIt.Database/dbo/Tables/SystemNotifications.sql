CREATE TABLE [dbo].[SystemNotifications](
	[Id] BIGINT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[Message] NVARCHAR(MAX) NOT NULL,
	[Code] NVARCHAR(50) NOT NULL,
	[Timestamp] [datetime] NOT NULL DEFAULT GETDATE(),
	[Active] [bit] NOT NULL DEFAULT 1
)