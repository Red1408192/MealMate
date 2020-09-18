
CREATE FUNCTION [dbo].[view_ingredient](@lang int)
RETURNS TABLE 
AS
RETURN 
(
	select	a.[ingredient_id],
			a.[parent_id],
			c1.localization as name,
			c2.localization as descriptionShort,
			c3.localization as descritpionLong,
			c4.username as username,
			a.[avg_life],
			c5.[unit_name] as unit,
			a.[specific_weight]
			
	from ingredient as a
	left join [localization_table] as c1 on a.[ing_name_id] = c1.[element_id] and c1.[language_id] = @lang
	left join [localization_table] as c2 on a.[ing_description_short_id] = c2.[element_id] and c2.[language_id] = @lang
	left join [localization_table] as c3 on a.[ing_description_long_id] = c3.[element_id] and c3.[language_id] = @lang

	left join [user] as c4 on a.[created_by_user] = c4.[user_id]
	left join [unit_type] as c5 on a.[unit_type] = c5.[unit_id]
)