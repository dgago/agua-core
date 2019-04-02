IF NOT EXISTS (SELECT name FROM sys.tables where name = 'DimVisitType')
	CREATE TABLE [dbo].[DimVisitType](
		[VisitTypeKey] [int] IDENTITY(1,1) NOT NULL,
		[VisitTypeInternalId] [smallint],
		[VisitTypeName] [nvarchar](50)
	 CONSTRAINT [PK_DimVisitType] PRIMARY KEY CLUSTERED 
	(
		[VisitTypeKey] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]