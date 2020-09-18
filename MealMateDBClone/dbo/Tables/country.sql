CREATE TABLE [dbo].[country] (
    [country_id]   INT        IDENTITY (1, 1) NOT NULL,
    [country_name] NCHAR (25) NOT NULL,
    [iso]          NCHAR (3)  NOT NULL,
    [def_language] INT        NOT NULL,
    [def_culture]  INT        NOT NULL,
    CONSTRAINT [PK_country] PRIMARY KEY CLUSTERED ([country_id] ASC),
    CONSTRAINT [FK_country_culture] FOREIGN KEY ([def_culture]) REFERENCES [dbo].[culture] ([culture_id]),
    CONSTRAINT [FK_country_language] FOREIGN KEY ([def_language]) REFERENCES [dbo].[language] ([language_id])
);

