CREATE TABLE [dbo].[user_settings] (
    [language_id]    INT            NOT NULL,
    [isPublic]       BIT            CONSTRAINT [DF_user_settings_isPublic] DEFAULT ((1)) NOT NULL,
    [def_country_id] INT            CONSTRAINT [DF_user_settings_def_country_id] DEFAULT ((1)) NOT NULL,
    [new_rec_sugg]   BIT            CONSTRAINT [DF_user_settings_new_rec_sugg] DEFAULT ((1)) NOT NULL,
    [exp_allarm]     BIT            CONSTRAINT [DF_user_settings_exp_allarm] DEFAULT ((1)) NOT NULL,
    [no_pantry]      BIT            CONSTRAINT [DF_user_settings_no_pantry] DEFAULT ((0)) NOT NULL,
    [user_id]        NVARCHAR (450) NOT NULL,
    CONSTRAINT [FK_user_settings_language] FOREIGN KEY ([language_id]) REFERENCES [dbo].[language] ([language_id]),
    CONSTRAINT [FK_user_settings_user] FOREIGN KEY ([user_id]) REFERENCES [dbo].[user] ([Id])
);

