CREATE TABLE [dbo].[recipe_step_ingredient] (
    [recipe_step_id]    INT        NOT NULL,
    [ingredient_id]     INT        NOT NULL,
    [ingredient_amount] FLOAT (53) CONSTRAINT [DF_recipe_step_ingredient_ingredient_amount] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [FK_recipe_step_ingredient_ingredient] FOREIGN KEY ([ingredient_id]) REFERENCES [dbo].[ingredient] ([ingredient_id]),
    CONSTRAINT [FK_recipe_step_ingredient_recipe_step] FOREIGN KEY ([recipe_step_id]) REFERENCES [dbo].[recipe_step] ([step_id])
);

