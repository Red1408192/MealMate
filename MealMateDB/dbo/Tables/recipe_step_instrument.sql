CREATE TABLE [dbo].[recipe_step_instrument] (
    [recipe_step_id]         INT NOT NULL,
    [recipe_step_instrument] INT NOT NULL,
    CONSTRAINT [FK_recipe_step_instrument_instrument] FOREIGN KEY ([recipe_step_instrument]) REFERENCES [dbo].[instrument] ([instrument_id]),
    CONSTRAINT [FK_recipe_step_instrument_recipe_step] FOREIGN KEY ([recipe_step_id]) REFERENCES [dbo].[recipe_step] ([step_id])
);

