IF NOT EXISTS (SELECT name FROM sys.tables where name = 'DimOrderStatus')
	CREATE TABLE [dbo].[DimOrderStatus](
		[OrderStatusKey] [int] IDENTITY(1,1) NOT NULL,
		[StatusInternalId] [int] NOT NULL,
		[StatusName] [nvarchar](255)	
	 CONSTRAINT [PK_DimOrderStatus] PRIMARY KEY CLUSTERED 
	(
		[OrderStatusKey] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]