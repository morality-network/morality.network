﻿CREATE TABLE [dbo].[PaymentTypes]
(
	[Id] BIGINT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [TypeName] NVARCHAR(50) NOT NULL
)
