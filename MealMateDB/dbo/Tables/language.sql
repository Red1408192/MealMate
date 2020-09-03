CREATE TABLE [dbo].[language] (
    [language_id] INT        IDENTITY (1, 1) NOT NULL,
    [name]        NCHAR (20) NOT NULL,
    CONSTRAINT [PK_language] PRIMARY KEY CLUSTERED ([language_id] ASC)
);

