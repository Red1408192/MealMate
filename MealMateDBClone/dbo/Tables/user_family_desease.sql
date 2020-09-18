CREATE TABLE [dbo].[user_family_desease] (
    [user_family_member_id] INT NOT NULL,
    [desease_id]            INT NOT NULL,
    CONSTRAINT [FK_user_family_desease_desease] FOREIGN KEY ([desease_id]) REFERENCES [dbo].[desease] ([desease_id]),
    CONSTRAINT [FK_user_family_desease_user_family] FOREIGN KEY ([user_family_member_id]) REFERENCES [dbo].[user_family] ([family_member])
);

