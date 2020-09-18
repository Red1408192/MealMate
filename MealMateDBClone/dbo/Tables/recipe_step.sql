CREATE TABLE [dbo].[recipe_step] (
    [step_id]              INT      IDENTITY (1, 1) NOT NULL,
    [recipe_id]            INT      NOT NULL,
    [action_id]            INT      NOT NULL,
    [time_cook]            SMALLINT CONSTRAINT [DF_recipe_step_time_cook] DEFAULT (NULL) NULL,
    [time_wait]            SMALLINT CONSTRAINT [DF_recipe_step_time_wait] DEFAULT (NULL) NULL,
    [output_ingredient_id] INT      CONSTRAINT [DF_recipe_step_output_ingredient_id] DEFAULT (NULL) NULL,
    CONSTRAINT [PK_recipe_step] PRIMARY KEY CLUSTERED ([step_id] ASC),
    CONSTRAINT [FK_recipe_step_action] FOREIGN KEY ([action_id]) REFERENCES [dbo].[action] ([action_id]),
    CONSTRAINT [FK_recipe_step_ingredient] FOREIGN KEY ([output_ingredient_id]) REFERENCES [dbo].[ingredient] ([ingredient_id]),
    CONSTRAINT [FK_recipe_step_recipe] FOREIGN KEY ([recipe_id]) REFERENCES [dbo].[recipe] ([recipe_id])
);

