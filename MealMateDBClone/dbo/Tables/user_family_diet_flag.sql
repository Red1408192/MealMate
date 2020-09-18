CREATE TABLE [dbo].[user_family_diet_flag] (
    [family_member_id] INT NOT NULL,
    [flag_id]          INT NOT NULL,
    CONSTRAINT [FK_user_family_diet_flag_flag] FOREIGN KEY ([flag_id]) REFERENCES [dbo].[flag] ([flag_id]),
    CONSTRAINT [FK_user_family_diet_flag_user_family] FOREIGN KEY ([family_member_id]) REFERENCES [dbo].[user_family] ([family_member])
);

