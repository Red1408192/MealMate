CREATE TABLE [dbo].[user_family] (
    [family_member] INT            IDENTITY (1, 1) NOT NULL,
    [name]          NCHAR (20)     NOT NULL,
    [second_name]   NCHAR (20)     NULL,
    [culture_id]    INT            NOT NULL,
    [isGuest]       BIT            CONSTRAINT [DF_user_family_isGuest] DEFAULT ((0)) NOT NULL,
    [user_id]       NVARCHAR (450) NULL,
    CONSTRAINT [PK_user_family] PRIMARY KEY CLUSTERED ([family_member] ASC),
    CONSTRAINT [FK_user_family_culture] FOREIGN KEY ([culture_id]) REFERENCES [dbo].[culture] ([culture_id]),
    CONSTRAINT [FK_user_family_user] FOREIGN KEY ([user_id]) REFERENCES [dbo].[user] ([Id])
);

