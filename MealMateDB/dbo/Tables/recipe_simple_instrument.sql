CREATE TABLE [dbo].[recipe_simple_instrument] (
    [recipe_id]     INT NOT NULL,
    [instrument_id] INT NOT NULL,
    CONSTRAINT [FK_recipe_simple_instrument_instrument] FOREIGN KEY ([instrument_id]) REFERENCES [dbo].[instrument] ([instrument_id]),
    CONSTRAINT [FK_recipe_simple_instrument_recipe] FOREIGN KEY ([recipe_id]) REFERENCES [dbo].[recipe] ([recipe_id])
);

