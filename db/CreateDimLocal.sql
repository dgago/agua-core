IF NOT EXISTS (SELECT name FROM sys.tables where name = 'DimLocal')
	CREATE TABLE [dbo].[DimLocal](
		[LocalKey] [int] IDENTITY(1,1) NOT NULL,
		[CodLocal] [nvarchar](255) NOT NULL,
		[LocalName] [nvarchar](255)	
	 CONSTRAINT [PK_DimLocal] PRIMARY KEY CLUSTERED 
	(
		[LocalKey] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]