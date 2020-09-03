CREATE TABLE [dbo].[meal_partecipants] (
    [meal_id]          INT NOT NULL,
    [user_id]          INT NOT NULL,
    [family_member_id] INT NOT NULL,
    CONSTRAINT [FK_meal_partecipants_meal] FOREIGN KEY ([meal_id]) REFERENCES [dbo].[meal] ([meal_id])
);

