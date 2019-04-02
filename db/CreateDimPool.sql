IF NOT EXISTS (SELECT name FROM sys.tables where name = 'DimPool')
	CREATE TABLE [dbo].[DimPool](
		[PoolKey] [int] IDENTITY(1,1) NOT NULL,
        [InternalPoolId] [int] NOT NULL,
		[CodLocal] [nvarchar](255) NOT NULL,
		[PoolName] [nvarchar](50) 
	 CONSTRAINT [PK_DimPool] PRIMARY KEY CLUSTERED 
	(
		[PoolKey] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]