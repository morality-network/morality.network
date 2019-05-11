CREATE TABLE [dbo].[ReportConfirm](
	[Id] [bigint] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[UserId] [bigint] NOT NULL,
	[InvestigationId] BIGINT NOT NULL,
	[Remove] [tinyint] NOT NULL,
    [Toxic] BIT NOT NULL, 
    [Racism] BIT NOT NULL, 
    [Obscene] BIT NOT NULL, 
    [Threat] BIT NOT NULL, 
    [Insult] BIT NOT NULL, 
    [Hate] BIT NOT NULL, 
    [Spam] BIT NOT NULL, 
    [RemoveComment] BIT NOT NULL, 
    [IsDeactivated] BIT NOT NULL DEFAULT 0, 
    CONSTRAINT [FK_ReportConfirm_ToUsers] FOREIGN KEY ([UserId]) REFERENCES [Users]([Id]), 
	CONSTRAINT [FK_ReportConfirm_ToInvestigations] FOREIGN KEY ([InvestigationId]) REFERENCES [Investigations]([Id])
)