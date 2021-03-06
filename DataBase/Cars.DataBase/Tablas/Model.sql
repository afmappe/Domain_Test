﻿CREATE TABLE [dbo].[MODEL]
(
    [id] INT NOT NULL IDENTITY, 
    [name] NVARCHAR(50) NOT NULL, 
    [brand_id] INT NOT NULL,

    CONSTRAINT [PK_MODEL] PRIMARY KEY([id]),    
    CONSTRAINT [FK01_MODEL] FOREIGN KEY ([brand_id]) REFERENCES [BRAND]([id]),
	CONSTRAINT [UX_MODEL] UNIQUE ([brand_id], [name]),
)
