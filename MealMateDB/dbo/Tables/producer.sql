CREATE TABLE [dbo].[producer] (
    [brand_id]     INT        IDENTITY (1, 1) NOT NULL,
    [brand_name]   NCHAR (20) NULL,
    [main_country] INT        NULL,
    CONSTRAINT [PK_brand] PRIMARY KEY CLUSTERED ([brand_id] ASC)
);

