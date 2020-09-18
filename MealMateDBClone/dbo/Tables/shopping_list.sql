CREATE TABLE [dbo].[shopping_list] (
    [shopping_list_id] INT      IDENTITY (1, 1) NOT NULL,
    [user_id]          INT      NOT NULL,
    [created_atDate]   DATETIME CONSTRAINT [DF_shopping_list_created_atDate] DEFAULT (getdate()) NOT NULL,
    [completed_atDate] DATETIME NULL,
    CONSTRAINT [PK_shopping_list] PRIMARY KEY CLUSTERED ([shopping_list_id] ASC)
);

