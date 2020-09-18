CREATE TABLE [dbo].[localization_table] (
    [element_id]   UNIQUEIDENTIFIER NOT NULL,
    [language_id]  INT              NOT NULL,
    [localization] NVARCHAR (MAX)   NULL,
    CONSTRAINT [FK_localization_table_language] FOREIGN KEY ([language_id]) REFERENCES [dbo].[language] ([language_id])
);

