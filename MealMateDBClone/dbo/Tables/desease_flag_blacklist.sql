CREATE TABLE [dbo].[desease_flag_blacklist] (
    [desease_id] INT NOT NULL,
    [flag_id]    INT NOT NULL,
    CONSTRAINT [FK_desease_flag_blacklist_desease] FOREIGN KEY ([desease_id]) REFERENCES [dbo].[desease] ([desease_id]),
    CONSTRAINT [FK_desease_flag_blacklist_flag] FOREIGN KEY ([flag_id]) REFERENCES [dbo].[flag] ([flag_id])
);

