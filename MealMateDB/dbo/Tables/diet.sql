CREATE TABLE [dbo].[diet] (
    [diet_id]      INT              NOT NULL,
    [diet_name_id] UNIQUEIDENTIFIER CONSTRAINT [DF_diet_diet_name_id] DEFAULT (newid()) NOT NULL,
    CONSTRAINT [PK_diet] PRIMARY KEY CLUSTERED ([diet_id] ASC)
);


GO
create TRIGGER [dbo].[remove_from_localization_table_diet]
   ON  [dbo].diet
   AFTER DELETE
AS 
BEGIN
	SET NOCOUNT ON;

	DELETE FROM dbo.localization_table
    WHERE element_id IN(SELECT deleted.diet_name_id FROM deleted)
END
GO
create TRIGGER [dbo].[add_to_localization_table_diet]
   ON  [dbo].[diet]
   AFTER INSERT
AS 
BEGIN
	SET NOCOUNT ON;
	DECLARE @i int = 1

	WHILE (@i <= 5)
		BEGIN
		   	insert into dbo.localization_table(element_id, language_id, localization)
			select ins.diet_name_id, @i, NULL from inserted as ins
		   SET @i = @i + 1;
		END;
END