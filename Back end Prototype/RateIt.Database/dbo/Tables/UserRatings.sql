CREATE TABLE [dbo].[UserRatings](
	[Id] [bigint] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[UserId] [bigint] NOT NULL,
	[RatingId] [bigint] NOT NULL,
	[Rating] [float] NOT NULL, 
    [Timestamp] DATETIME NOT NULL DEFAULT GETDATE(), 
    CONSTRAINT [FK_UserRatings_ToUsers] FOREIGN KEY ([UserId]) REFERENCES [Users]([Id]), 
    CONSTRAINT [FK_UserRatings_ToRatings] FOREIGN KEY ([RatingId]) REFERENCES [Ratings]([Id])
)