CREATE TABLE [dbo].[culture] (
    [culture_id]  INT              IDENTITY (1, 1) NOT NULL,
    [cul_name_id] UNIQUEIDENTIFIER CONSTRAINT [DF_culture_cul_name_id] DEFAULT (newid()) NOT NULL,
    CONSTRAINT [PK_culture] PRIMARY KEY CLUSTERED ([culture_id] ASC)
);


GO
Create TRIGGER [dbo].[remove_from_localization_table_cul]
   ON  [dbo].[culture]
   AFTER DELETE
AS 
BEGIN
	SET NOCOUNT ON;

	DELETE FROM dbo.localization_table
    WHERE element_id IN(SELECT deleted.cul_name_id FROM deleted)
END
GO
Create TRIGGER [dbo].[add_to_localization_table_cul]
   ON  [dbo].[culture]
   AFTER INSERT
AS 
BEGIN
	SET NOCOUNT ON;
	DECLARE @i int = 1

	WHILE (@i <= 5)
		BEGIN
		   	insert into dbo.localization_table(element_id, language_id, localization)
			select ins.cul_name_id, @i, NULL from inserted as ins

		   SET @i = @i + 1;
		END;
END