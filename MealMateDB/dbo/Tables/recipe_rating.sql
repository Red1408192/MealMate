CREATE TABLE [dbo].[recipe_rating] (
    [rating_id] INT  NOT NULL,
    [user_id]   INT  NOT NULL,
    [recipe_id] INT  NOT NULL,
    [liked]     BIT  CONSTRAINT [DF_recipe_rating_liked] DEFAULT ((1)) NOT NULL,
    [comment]   TEXT NULL,
    CONSTRAINT [PK_recipe_rating] PRIMARY KEY CLUSTERED ([rating_id] ASC),
    CONSTRAINT [FK_recipe_rating_recipe] FOREIGN KEY ([recipe_id]) REFERENCES [dbo].[recipe] ([recipe_id])
);

