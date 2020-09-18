CREATE TABLE [dbo].[diet_flag_blacklist] (
    [diet_id] INT NOT NULL,
    [flag_id] INT NOT NULL,
    CONSTRAINT [FK_diet_flag_blacklist_diet] FOREIGN KEY ([diet_id]) REFERENCES [dbo].[diet] ([diet_id]),
    CONSTRAINT [FK_diet_flag_blacklist_flag] FOREIGN KEY ([flag_id]) REFERENCES [dbo].[flag] ([flag_id])
);

