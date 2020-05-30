CREATE TABLE [dbo].[Restrictions]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [Name] NVARCHAR(100) NOT NULL, 
    [Reason] NVARCHAR(MAX) NULL, 
    [Active] BIT NOT NULL DEFAULT 1, 
    [TimeStamp] DATETIME NOT NULL DEFAULT GETDATE(), 
    [CountryCodeId] INT NULL, 
    CONSTRAINT [FK_Restrictions_ToCountryCodes] FOREIGN KEY (CountryCodeId) REFERENCES [CountryCodes]([Id])
)
