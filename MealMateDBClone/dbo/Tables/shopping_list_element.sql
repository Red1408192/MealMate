CREATE TABLE [dbo].[shopping_list_element] (
    [shopping_list_id] INT NOT NULL,
    [ingredient_id]    INT NOT NULL,
    [quantity]         INT CONSTRAINT [DF_shopping_list_element_quantity] DEFAULT ((1)) NOT NULL,
    [is_fullfilled]    BIT CONSTRAINT [DF_shopping_list_element_is_fullfilled] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [FK_shopping_list_element_ingredient] FOREIGN KEY ([ingredient_id]) REFERENCES [dbo].[ingredient] ([ingredient_id]),
    CONSTRAINT [FK_shopping_list_element_shopping_list] FOREIGN KEY ([shopping_list_id]) REFERENCES [dbo].[shopping_list] ([shopping_list_id])
);

