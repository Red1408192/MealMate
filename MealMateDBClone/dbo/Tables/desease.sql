CREATE TABLE [dbo].[desease] (
    [desease_id]      INT              NOT NULL,
    [desease_name_id] UNIQUEIDENTIFIER CONSTRAINT [DF_desease_desease_name_id] DEFAULT (newid()) NOT NULL,
    CONSTRAINT [PK_desease] PRIMARY KEY CLUSTERED ([desease_id] ASC)
);


GO
create TRIGGER [dbo].[remove_from_localization_table_deseae]
   ON  [dbo].desease
   AFTER DELETE
AS 
BEGIN
	SET NOCOUNT ON;

	DELETE FROM dbo.localization_table
    WHERE element_id IN(SELECT deleted.desease_name_id FROM deleted)
END
GO
create TRIGGER [dbo].[add_to_localization_table_desease]
   ON  [dbo].desease
   AFTER INSERT
AS 
BEGIN
	SET NOCOUNT ON;
	DECLARE @i int = 1

	WHILE (@i <= 5)
		BEGIN
		   	insert into dbo.localization_table(element_id, language_id, localization)
			select ins.desease_name_id, @i, NULL from inserted as ins
		   SET @i = @i + 1;
		END;
END