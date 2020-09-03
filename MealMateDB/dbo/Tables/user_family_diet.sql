CREATE TABLE [dbo].[user_family_diet] (
    [User_family_member_id] INT NOT NULL,
    [diet_id]               INT NOT NULL,
    CONSTRAINT [FK_user_family_diet_diet] FOREIGN KEY ([diet_id]) REFERENCES [dbo].[diet] ([diet_id]),
    CONSTRAINT [FK_user_family_diet_user_family] FOREIGN KEY ([User_family_member_id]) REFERENCES [dbo].[user_family] ([family_member])
);

