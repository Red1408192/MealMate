CREATE TABLE [dbo].[pantry] (
    [pantry_id] INT            IDENTITY (1, 1) NOT NULL,
    [user_id]   NVARCHAR (450) NOT NULL,
    CONSTRAINT [PK_pantry] PRIMARY KEY CLUSTERED ([pantry_id] ASC),
    CONSTRAINT [FK_pantry_user] FOREIGN KEY ([user_id]) REFERENCES [dbo].[user] ([Id])
);

