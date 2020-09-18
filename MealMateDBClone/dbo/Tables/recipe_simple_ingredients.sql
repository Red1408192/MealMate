CREATE TABLE [dbo].[recipe_simple_ingredients] (
    [recipe_id]     INT        NOT NULL,
    [ingredient_id] INT        NOT NULL,
    [quantity]      FLOAT (53) NOT NULL,
    CONSTRAINT [FK_recipe_simple_ingredients_ingredient] FOREIGN KEY ([ingredient_id]) REFERENCES [dbo].[ingredient] ([ingredient_id]),
    CONSTRAINT [FK_recipe_simple_ingredients_recipe] FOREIGN KEY ([recipe_id]) REFERENCES [dbo].[recipe] ([recipe_id])
);

