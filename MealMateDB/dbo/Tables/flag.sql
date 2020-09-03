CREATE TABLE [dbo].[flag] (
    [flag_id]             INT              IDENTITY (1, 1) NOT NULL,
    [flag_name_id]        UNIQUEIDENTIFIER CONSTRAINT [DF_Note_not_name_id] DEFAULT (newid()) NOT NULL,
    [flag_description_id] UNIQUEIDENTIFIER CONSTRAINT [DF_Note_not_description_id] DEFAULT (newid()) NOT NULL,
    CONSTRAINT [PK_Note] PRIMARY KEY CLUSTERED ([flag_id] ASC)
);


GO

CREATE TRIGGER remove_from_localization_table_note
   ON  [dbo].[flag]
   AFTER DELETE
AS 
BEGIN
	SET NOCOUNT ON;

	DELETE FROM dbo.localization_table
    WHERE element_id IN(SELECT deleted.name_id FROM deleted)

	DELETE FROM dbo.localization_table
    WHERE element_id IN(SELECT deleted.description_id FROM deleted)
END
GO

CREATE TRIGGER add_to_localization_table_note
   ON  [dbo].[flag]
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
			select ins.name_id, @i, NULL from inserted as ins

			insert into dbo.localization_table(element_id, language_id, localization)
			select ins.description_id, @i, NULL from inserted as ins
		   SET @i = @i + 1;
		END;
END