CREATE TABLE [dbo].[pantry_ingredient] (
    [pantry_oc_id]  INT        NOT NULL,
    [ingredient_id] INT        NOT NULL,
    [quantity]      FLOAT (53) NOT NULL,
    CONSTRAINT [FK_pantry_ingredient_ingredient] FOREIGN KEY ([ingredient_id]) REFERENCES [dbo].[ingredient] ([ingredient_id]),
    CONSTRAINT [FK_pantry_ingredient_pantry_overcard] FOREIGN KEY ([pantry_oc_id]) REFERENCES [dbo].[pantry_overcard] ([pantry_overcard_id])
);

