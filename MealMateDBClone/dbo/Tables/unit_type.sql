CREATE TABLE [dbo].[unit_type] (
    [unit_id]   INT        IDENTITY (1, 1) NOT NULL,
    [unit_name] NCHAR (15) NOT NULL,
    CONSTRAINT [PK_unit_type] PRIMARY KEY CLUSTERED ([unit_id] ASC)
);

