CREATE TABLE [dbo].[locations] (
    [location_id] INT        IDENTITY (1, 1) NOT NULL,
    [country_id]  INT        NOT NULL,
    [zip_code]    NCHAR (12) NOT NULL,
    CONSTRAINT [PK_locations] PRIMARY KEY CLUSTERED ([location_id] ASC),
    CONSTRAINT [FK_locations_country] FOREIGN KEY ([country_id]) REFERENCES [dbo].[country] ([country_id])
);

