CREATE TABLE [dbo].[user_family_diet_ingr] (
    [family_member_id] INT NOT NULL,
    [ingredient_id]    INT NOT NULL,
    CONSTRAINT [FK_user_family_diet_ingr_ingredient] FOREIGN KEY ([ingredient_id]) REFERENCES [dbo].[ingredient] ([ingredient_id]),
    CONSTRAINT [FK_user_family_diet_ingr_user_family] FOREIGN KEY ([family_member_id]) REFERENCES [dbo].[user_family] ([family_member])
);

