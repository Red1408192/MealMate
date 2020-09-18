CREATE TABLE [dbo].[recipe_step_flag] (
    [recipe_step_id] INT NOT NULL,
    [flag_id]        INT NOT NULL,
    CONSTRAINT [FK_recipe_step_note_Note] FOREIGN KEY ([flag_id]) REFERENCES [dbo].[flag] ([flag_id]),
    CONSTRAINT [FK_recipe_step_note_recipe_step] FOREIGN KEY ([recipe_step_id]) REFERENCES [dbo].[recipe_step] ([step_id])
);

