CREATE TABLE [dbo].[CAR]
(
	[id] INT NOT NULL IDENTITY, 
    [model_id] INT NOT NULL, 
    [year] INT NOT NULL, 
    [license] NVARCHAR(50) NULL, 
    [is_new] BIT NOT NULL DEFAULT (0), 
    [is_available] BIT NOT NULL DEFAULT(1), 
    [image] IMAGE NULL, 
	
	CONSTRAINT [PK_CAR] PRIMARY KEY ([id]),	
    CONSTRAINT [FK01_CAR] FOREIGN KEY ([model_id]) REFERENCES [MODEL]([id]),	
)
GO
CREATE INDEX [IX01_CAR] ON [dbo].[CAR]([license])
WHERE([license] IS NOT NULL);
