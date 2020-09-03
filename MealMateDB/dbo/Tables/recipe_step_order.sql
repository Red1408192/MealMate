CREATE TABLE [dbo].[recipe_step_order] (
    [recipe_step_id]       INT NOT NULL,
    [vetex_recipe_step_id] INT NOT NULL,
    CONSTRAINT [PK_recipe_step_order] PRIMARY KEY CLUSTERED ([recipe_step_id] ASC),
    CONSTRAINT [FK_recipe_step_order_recipe_step2] FOREIGN KEY ([recipe_step_id]) REFERENCES [dbo].[recipe_step] ([step_id]),
    CONSTRAINT [FK_recipe_step_order_recipe_step3] FOREIGN KEY ([vetex_recipe_step_id]) REFERENCES [dbo].[recipe_step] ([step_id])
);

