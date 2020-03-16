alter table [moralityapp].[dbo].[AspNetUsers]
add CurrentAppId nvarchar(500) NOT NULL;
alter table [moralityapp].[dbo].[AspNetUsers]
add IsNew bit NOT NULL DEFAULT 0;