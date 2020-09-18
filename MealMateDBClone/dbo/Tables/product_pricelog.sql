CREATE TABLE [dbo].[product_pricelog] (
    [product_id] INT      NOT NULL,
    [price]      INT      NOT NULL,
    [country]    INT      NOT NULL,
    [date]       DATETIME CONSTRAINT [DF_price_log_date] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [FK_product_pricelog_country] FOREIGN KEY ([country]) REFERENCES [dbo].[country] ([country_id]),
    CONSTRAINT [FK_product_pricelog_product_table] FOREIGN KEY ([product_id]) REFERENCES [dbo].[product_table] ([product_table_id])
);

