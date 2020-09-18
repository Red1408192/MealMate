CREATE TABLE [dbo].[pantry_overcard] (
    [pantry_overcard_id] INT        NOT NULL,
    [pantry_id]          INT        NOT NULL,
    [name]               NCHAR (30) CONSTRAINT [DF_pantry_overcard_name] DEFAULT (N'newOverCard') NOT NULL,
    CONSTRAINT [PK_pantry_overcard] PRIMARY KEY CLUSTERED ([pantry_overcard_id] ASC),
    CONSTRAINT [FK_pantry_overcard_pantry] FOREIGN KEY ([pantry_id]) REFERENCES [dbo].[pantry] ([pantry_id])
);

