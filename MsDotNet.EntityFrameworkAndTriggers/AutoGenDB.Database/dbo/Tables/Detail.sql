CREATE TABLE [dbo].[Detail] (
    [Id]            INT         IDENTITY (1, 1) NOT NULL,
    [MasterId]      INT         NOT NULL,
    [AutoGenPrefix] VARCHAR (5) NULL,
    [AutoGenNumber] INT         NULL,
    CONSTRAINT [PK_Detail] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Detail_Master] FOREIGN KEY ([MasterId]) REFERENCES [dbo].[Master] ([Id])
);


GO
CREATE TRIGGER  [dbo].[Insert_Detail_ReadableId]
ON [dbo].[Detail]
INSTEAD OF INSERT
AS
BEGIN
   SET NOCOUNT OFF;
	INSERT INTO [Detail] ([MasterId],[AutoGenPrefix], [AutoGenNumber])
	SELECT 
		I.[MasterId] AS [MasterId],
		M2.AutoGenPrefix AS [AutoGenPrefix],
		ISNULL(ROW_NUMBER() OVER(ORDER BY I.[Id]) + M.[AutoGenNumber],1) AS [AutoGenNumber]
	FROM INSERTED  I
	LEFT JOIN [Master] M2 ON I.[MasterId] = M2.[Id]
	LEFT JOIN (
		SELECT 
			[MasterId],
			MAX(ISNULL([AutoGenNumber],0)) AS [AutoGenNumber]
		FROM [AutoGenDB].[dbo].[Detail]
		GROUP BY [MasterId]
	) M ON I.[MasterId] = M.[MasterId]

	--SET NOCOUNT OFF;
	SELECT [Id] FROM [Detail] WHERE @@ROWCOUNT > 0 AND [Id] = SCOPE_IDENTITY();
END