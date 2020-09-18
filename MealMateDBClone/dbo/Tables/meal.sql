CREATE TABLE [dbo].[meal] (
    [meal_id]    INT  IDENTITY (1, 1) NOT NULL,
    [user_id]    INT  NOT NULL,
    [planed_for] DATE NOT NULL,
    [daybanch]   INT  NOT NULL,
    CONSTRAINT [PK_meal] PRIMARY KEY CLUSTERED ([meal_id] ASC)
);

