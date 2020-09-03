CREATE TABLE [dbo].[instrument] (
    [instrument_id]            INT              IDENTITY (1, 1) NOT NULL,
    [ins_name_id]              UNIQUEIDENTIFIER CONSTRAINT [DF_instrument_ins_name_id] DEFAULT (newid()) NOT NULL,
    [ins_description_short_id] UNIQUEIDENTIFIER CONSTRAINT [DF_instrument_ins_description_short_id] DEFAULT (newid()) NOT NULL,
    [ins_description_long_id]  UNIQUEIDENTIFIER CONSTRAINT [DF_instrument_ins_description_long_id] DEFAULT (newid()) NOT NULL,
    CONSTRAINT [PK_instrument] PRIMARY KEY CLUSTERED ([instrument_id] ASC)
);


GO

CREATE TRIGGER remove_from_localization_table_instr
   ON  dbo.instrument
   AFTER DELETE
AS 
BEGIN
	SET NOCOUNT ON;

	DELETE FROM dbo.localization_table
    WHERE element_id IN(SELECT deleted.name_id FROM deleted)

	DELETE FROM dbo.localization_table
    WHERE element_id IN(SELECT deleted.description_short_id FROM deleted)

	DELETE FROM dbo.localization_table
    WHERE element_id IN(SELECT deleted.description_long_id FROM deleted)
END
GO

CREATE TRIGGER add_to_localization_table_instr
   ON  dbo.instrument
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
			select ins.description_short_id, @i, NULL from inserted as ins

			insert into dbo.localization_table(element_id, language_id, localization)
			select  ins.description_long_id, @i, NULL from inserted as ins
		   SET @i = @i + 1;
		END;
END