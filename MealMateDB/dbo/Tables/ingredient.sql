CREATE TABLE [dbo].[ingredient] (
    [ingredient_id]            INT              IDENTITY (1, 1) NOT NULL,
    [parent_id]                INT              CONSTRAINT [DF_ingredient_parent_id] DEFAULT ((1)) NULL,
    [ing_name_id]              UNIQUEIDENTIFIER CONSTRAINT [DF_ingredient_ing_name_id] DEFAULT (newid()) NOT NULL,
    [ing_description_short_id] UNIQUEIDENTIFIER CONSTRAINT [DF_ingredient_ing_description_short_id] DEFAULT (newid()) NOT NULL,
    [ing_description_long_id]  UNIQUEIDENTIFIER CONSTRAINT [DF_ingredient_ing_description_long_id] DEFAULT (newid()) NOT NULL,
    [detail_table_id]          INT              CONSTRAINT [DF_ingredient_detail_table_id] DEFAULT (NULL) NULL,
    [product_table_id]         INT              CONSTRAINT [DF_ingredient_product_table_id] DEFAULT (NULL) NULL,
    CONSTRAINT [PK_ingredient_1] PRIMARY KEY CLUSTERED ([ingredient_id] ASC),
    CONSTRAINT [FK_ingredient_ingredient] FOREIGN KEY ([parent_id]) REFERENCES [dbo].[ingredient] ([ingredient_id]),
    CONSTRAINT [FK_ingredient_product_table] FOREIGN KEY ([product_table_id]) REFERENCES [dbo].[product_table] ([product_table_id])
);


GO
CREATE TRIGGER [dbo].[remove_from_localization_table_ingr]
   ON  dbo.ingredient
   AFTER DELETE
AS 
BEGIN
	SET NOCOUNT ON;

	DELETE FROM dbo.localization_table
    WHERE element_id IN(SELECT deleted.ing_name_id FROM deleted)

	DELETE FROM dbo.localization_table
    WHERE element_id IN(SELECT deleted.ing_description_short_id FROM deleted)

	DELETE FROM dbo.localization_table
    WHERE element_id IN(SELECT deleted.ing_description_long_id FROM deleted)
END
GO
CREATE TRIGGER [dbo].[add_to_localization_table_ingr]
   ON  dbo.ingredient
   AFTER INSERT
AS 
BEGIN
	SET NOCOUNT ON;
	DECLARE @i int = 1

	WHILE (@i <= 5)
		BEGIN
		   	insert into dbo.localization_table(element_id, language_id, localization)
			select ins.ing_name_id, @i, NULL from inserted as ins

			insert into dbo.localization_table(element_id, language_id, localization)
			select ins.ing_description_short_id, @i, NULL from inserted as ins

			insert into dbo.localization_table(element_id, language_id, localization)
			select  ins.ing_description_long_id, @i, NULL from inserted as ins
		   SET @i = @i + 1;
		END;
END