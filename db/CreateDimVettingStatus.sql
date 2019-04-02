IF NOT EXISTS (SELECT name FROM sys.tables where name = 'DimVettingStatus')
	CREATE TABLE [dbo].[DimVettingStatus](
		[VettingStatusKey] [int] IDENTITY(1,1) NOT NULL,
		[StatusInternalId] [int] NOT NULL,
		[StatusName] [nvarchar](50)	
	 CONSTRAINT [PK_DimVettingStatus] PRIMARY KEY CLUSTERED 
	(
		[VettingStatusKey] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]