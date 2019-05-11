CREATE TABLE [dbo].[Ratings](
	[Id] [bigint] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[RatingValue] [float] NOT NULL DEFAULT 0,
	[SubDirectoryId] [bigint] NOT NULL, 
    CONSTRAINT [FK_Ratings_ToSubDirectory] FOREIGN KEY ([SubDirectoryId]) REFERENCES [SubDirectorys]([Id]),
)