CREATE TABLE [dbo].[recipe] (
    [recipe_id]                INT              IDENTITY (1, 1) NOT NULL,
    [rec_name_id]              UNIQUEIDENTIFIER CONSTRAINT [DF_recipe_rec_name_id] DEFAULT (newid()) NOT NULL,
    [rec_description_short_id] UNIQUEIDENTIFIER CONSTRAINT [DF_recipe_rec_description_short_id] DEFAULT (newid()) NOT NULL,
    [rec_description_long_id]  UNIQUEIDENTIFIER CONSTRAINT [DF_recipe_rec_description_long_id] DEFAULT (newid()) NOT NULL,
    [created_inDate]           DATETIME         CONSTRAINT [DF_recipe_created_inDate] DEFAULT (getdate()) NOT NULL,
    [created_byUser]           INT              CONSTRAINT [DF_recipe_created_byUser] DEFAULT ((1)) NOT NULL,
    [isPublic]                 BIT              CONSTRAINT [DF_recipe_isPublic] DEFAULT ((1)) NOT NULL,
    [difficulty_rating]        SMALLINT         CONSTRAINT [DF_recipe_difficulty_rating] DEFAULT ((3)) NOT NULL,
    [total_time_cook]          SMALLINT         NULL,
    [total_time_wait]          SMALLINT         NULL,
    [culture_id]               INT              NULL,
    CONSTRAINT [PK_recipe] PRIMARY KEY CLUSTERED ([recipe_id] ASC),
    CONSTRAINT [FK_recipe_culture] FOREIGN KEY ([culture_id]) REFERENCES [dbo].[culture] ([culture_id])
);


GO
CREATE TRIGGER [dbo].[add_to_localization_table_recipe]
   ON  dbo.recipe
   AFTER INSERT
AS 
BEGIN
	SET NOCOUNT ON;
	DECLARE @lang TABLE (
    idx int Primary Key IDENTITY(1,1)
    , language_id int)
	DECLARE @i int = 1

	WHILE (@i <= (SELECT MAX(idx) FROM @lang))
		BEGIN
		   	insert into dbo.localization_table(element_id, language_id, localization)
			select ins.rec_name_id, @i, NULL from inserted as ins

			insert into dbo.localization_table(element_id, language_id, localization)
			select ins.rec_description_short_id, @i, NULL from inserted as ins

			insert into dbo.localization_table(element_id, language_id, localization)
			select  ins.rec_description_long_id, @i, NULL from inserted as ins
		   SET @i = @i + 1;
		END;
END
GO
CREATE TRIGGER [dbo].[remove_from_localization_table_recipe]
   ON  dbo.recipe
   AFTER DELETE
AS 
BEGIN
	SET NOCOUNT ON;

	DELETE FROM dbo.localization_table
    WHERE element_id IN(SELECT deleted.rec_name_id FROM deleted)

	DELETE FROM dbo.localization_table
    WHERE element_id IN(SELECT deleted.rec_description_short_id FROM deleted)

	DELETE FROM dbo.localization_table
    WHERE element_id IN(SELECT deleted.rec_description_long_id FROM deleted)
END