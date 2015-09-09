CREATE TABLE [dbo].[Master] (
    [Id]            INT         IDENTITY (1, 1) NOT NULL,
    [IsAutoGen]     BIT         CONSTRAINT [DF_Master_IsAutoGen] DEFAULT ((0)) NOT NULL,
    [AutoGenPrefix] VARCHAR (5) NULL,
    CONSTRAINT [PK_Master] PRIMARY KEY CLUSTERED ([Id] ASC)
);

