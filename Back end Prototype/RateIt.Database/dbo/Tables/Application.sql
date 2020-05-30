CREATE TABLE [dbo].[Application]
(
	[Id] INT NOT NULL Identity(1,1)  PRIMARY KEY, 
    [LastUpdatedDate] DATETIME NOT NULL DEFAULT GETDATE(), 
    [AirdropLastRunAt] DATETIME NULL,

)
