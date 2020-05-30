CREATE TABLE [dbo].[CountryCodes]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [Code] NVARCHAR(5) NULL, 
    [EnglishName] NVARCHAR(100) NULL, 
    [FrenchName] NVARCHAR(100) NULL
)
