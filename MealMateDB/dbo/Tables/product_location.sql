CREATE TABLE [dbo].[product_location] (
    [product_id]  INT NOT NULL,
    [location_id] INT NOT NULL,
    CONSTRAINT [FK_ingredient_location_ingredient] FOREIGN KEY ([product_id]) REFERENCES [dbo].[ingredient] ([ingredient_id]),
    CONSTRAINT [FK_ingredient_location_locations] FOREIGN KEY ([location_id]) REFERENCES [dbo].[locations] ([location_id])
);

