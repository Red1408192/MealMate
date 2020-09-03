CREATE TABLE [dbo].[product_table] (
    [product_table_id] INT        IDENTITY (1, 1) NOT NULL,
    [producer_id]      INT        NOT NULL,
    [unit_type]        INT        CONSTRAINT [DF_product_table_Unit_type] DEFAULT ((3)) NOT NULL,
    [Quantity]         FLOAT (53) NOT NULL,
    CONSTRAINT [PK_product_table] PRIMARY KEY CLUSTERED ([product_table_id] ASC),
    CONSTRAINT [FK_product_table_brand] FOREIGN KEY ([producer_id]) REFERENCES [dbo].[producer] ([brand_id]),
    CONSTRAINT [FK_product_table_unit_type] FOREIGN KEY ([unit_type]) REFERENCES [dbo].[unit_type] ([unit_id])
);

