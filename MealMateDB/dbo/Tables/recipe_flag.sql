CREATE TABLE [dbo].[recipe_flag] (
    [recipe_id] INT NOT NULL,
    [flag_id]   INT NOT NULL,
    CONSTRAINT [FK_recipe_flag_flag] FOREIGN KEY ([flag_id]) REFERENCES [dbo].[flag] ([flag_id]),
    CONSTRAINT [FK_recipe_flag_recipe] FOREIGN KEY ([recipe_id]) REFERENCES [dbo].[recipe] ([recipe_id])
);

