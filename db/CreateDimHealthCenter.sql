IF NOT EXISTS (SELECT name FROM sys.tables where name = 'DimHealthCenter')
	CREATE TABLE [dbo].[DimHealthCenter](
		[HealthCenterKey] [int] IDENTITY(1,1) NOT NULL,
		[HealthCenterCod] [nvarchar](50),
		[HealthCenterCodName] [nvarchar](50)	
	 CONSTRAINT [PK_DimHealthCenter] PRIMARY KEY CLUSTERED 
	(
		[HealthCenterKey] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]