CREATE TABLE [dbo].[desease_ingredient_blacklist] (
    [desease_id]    INT NULL,
    [ingredient_id] INT NOT NULL,
    CONSTRAINT [FK_desease_ingredient_blacklist_desease] FOREIGN KEY ([desease_id]) REFERENCES [dbo].[desease] ([desease_id]),
    CONSTRAINT [FK_desease_ingredient_blacklist_ingredient] FOREIGN KEY ([ingredient_id]) REFERENCES [dbo].[ingredient] ([ingredient_id])
);

