CREATE TABLE [dbo].[meal_recipes] (
    [meal_id]        INT        NOT NULL,
    [recipe_id]      INT        NOT NULL,
    [persons_served] INT        NOT NULL,
    [portions]       FLOAT (53) NOT NULL,
    CONSTRAINT [FK_meal_recipes_meal] FOREIGN KEY ([meal_id]) REFERENCES [dbo].[meal] ([meal_id]),
    CONSTRAINT [FK_meal_recipes_recipe] FOREIGN KEY ([recipe_id]) REFERENCES [dbo].[recipe] ([recipe_id])
);

