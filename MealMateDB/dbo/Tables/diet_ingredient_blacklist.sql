CREATE TABLE [dbo].[diet_ingredient_blacklist] (
    [diet_id]       INT NOT NULL,
    [ingredient_id] INT NOT NULL,
    CONSTRAINT [FK_diet_ingredient_blacklist_diet] FOREIGN KEY ([diet_id]) REFERENCES [dbo].[diet] ([diet_id]),
    CONSTRAINT [FK_diet_ingredient_blacklist_ingredient1] FOREIGN KEY ([ingredient_id]) REFERENCES [dbo].[ingredient] ([ingredient_id])
);

