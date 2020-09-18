
CREATE PROCEDURE [dbo].[InsertNewIngredientShort] (@parentId int, @ingredientName text,
	@descriptionShort text, @descriptionLong text, @avgLife int, @unitType int,
	@specificWheight float, @language int)
AS
BEGIN
	SET NOCOUNT ON;

	declare @ids table(names uniqueidentifier, descriptions1 uniqueidentifier, descriptions2 uniqueidentifier)

	insert into dbo.ingredient ([parent_id], [avg_life], [unit_type], [specific_weight])
	output inserted.ing_name_id, inserted.ing_description_short_id, inserted.ing_description_long_id INTO @ids
	values (@parentId, @avgLife, @unitType, @specificWheight)
	--
	declare @nameId uniqueidentifier
	select @nameId = names from @ids

	declare @descShortId uniqueidentifier
	select @descShortId = descriptions1 from @ids

	declare @descLongId uniqueidentifier
	select @descLongId = descriptions2 from @ids

	update dbo.[localization_table]
	set localization = @ingredientName
	where [language_id] = @language and [element_id] = @nameId

	update dbo.[localization_table]
	set localization = @descriptionShort
	where [language_id] = @language and [element_id] = @descShortId

	update dbo.[localization_table]
	set localization = @descriptionLong
	where [language_id] = @language and [element_id] = @descLongId
END