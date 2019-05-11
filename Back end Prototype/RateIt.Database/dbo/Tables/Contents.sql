CREATE TABLE [dbo].[Contents]
(
	[Id] BIGINT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [Timestamp] DATETIME NOT NULL DEFAULT GETDATE(), 
	[SubDirectoryId] [bigint] NOT NULL, 
	[ExistsOnBlockChain] BIT NOT NULL DEFAULT 0, 
    [Comments] NVARCHAR(1000) NULL,
	[AppliedForPersistence] BIT NOT NULL DEFAULT 0, 
    [AppliedForPersistencedAt] DATETIME NULL , 
    [EligableForPersistance] BIT NOT NULL DEFAULT 0, 
    [EligableForPersistanceAt] DATETIME NULL , 
    [ContentTypeId] BIGINT NOT NULL, 
    [PublisherChannelId] BIGINT NULL, 
	[ValidationRunCount] INT NOT NULL DEFAULT 1, 
    [ReferredViaValidationToAdmin] BIT NOT NULL DEFAULT 0, 
    CONSTRAINT [FK_Contents_ToPublisherChannel] FOREIGN KEY ([PublisherChannelId]) REFERENCES [PublisherChannel]([Id]),
    CONSTRAINT [FK_Contents_ToSubDirectorys] FOREIGN KEY ([SubDirectoryId]) REFERENCES [SubDirectorys]([Id]), 
    CONSTRAINT [FK_Contents_ToContentTypes] FOREIGN KEY ([ContentTypeId]) REFERENCES [ContentTypes]([Id])
)
