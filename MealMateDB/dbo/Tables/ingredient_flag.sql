CREATE TABLE [dbo].[ingredient_flag] (
    [ingredient_id] INT NOT NULL,
    [flag_id]       INT NOT NULL,
    CONSTRAINT [FK_ingredient_flag_flag] FOREIGN KEY ([flag_id]) REFERENCES [dbo].[flag] ([flag_id]),
    CONSTRAINT [FK_ingredient_flag_ingredient] FOREIGN KEY ([ingredient_id]) REFERENCES [dbo].[ingredient] ([ingredient_id])
);

