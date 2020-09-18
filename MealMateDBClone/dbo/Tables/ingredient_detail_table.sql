CREATE TABLE [dbo].[ingredient_detail_table] (
    [detail_table_id]           INT        IDENTITY (1, 1) NOT NULL,
    [avg_life]                  INT        CONSTRAINT [DF_ingredient_detail_table_avg_life] DEFAULT ((0)) NOT NULL,
    [unit_type]                 INT        CONSTRAINT [DF_ingredient_detail_table_unit_type] DEFAULT ((3)) NOT NULL,
    [specific_weight]           FLOAT (53) NULL,
    [prop_water]                FLOAT (53) NULL,
    [prop_protein]              FLOAT (53) NULL,
    [prop_fat_total]            FLOAT (53) NULL,
    [prop_fat_saturated]        FLOAT (53) NULL,
    [prop_fat_unsaturated_mono] FLOAT (53) NULL,
    [prop_fat_unsaturated_poly] FLOAT (53) NULL,
    [prop_cholesterol]          FLOAT (53) NULL,
    [prop_Carbohydrate]         FLOAT (53) NULL,
    [prop_fiber]                FLOAT (53) NULL,
    [prop_calcium]              FLOAT (53) NULL,
    [prop_iron]                 FLOAT (53) NULL,
    [prop_potasium]             FLOAT (53) NULL,
    [prop_sodium]               FLOAT (53) NULL,
    [prop_vitA_IU]              FLOAT (53) NULL,
    [prop_vitA_RE]              FLOAT (53) NULL,
    [prop_vitB_1]               FLOAT (53) NULL,
    [prop_vitB_2]               FLOAT (53) NULL,
    [prop_vitB_3]               FLOAT (53) NULL,
    [prop_vitC]                 FLOAT (53) NULL,
    CONSTRAINT [PK_ingredient_detail_table] PRIMARY KEY CLUSTERED ([detail_table_id] ASC),
    CONSTRAINT [FK_ingredient_detail_table_ingredient] FOREIGN KEY ([detail_table_id]) REFERENCES [dbo].[ingredient] ([ingredient_id]),
    CONSTRAINT [FK_ingredient_detail_table_unit_type] FOREIGN KEY ([unit_type]) REFERENCES [dbo].[unit_type] ([unit_id])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Average days of life in optimal conditions', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ingredient_detail_table';

