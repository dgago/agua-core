IF NOT EXISTS (SELECT name FROM sys.tables where name = 'DimWorkstation')
	CREATE TABLE [dbo].[DimWorkstation](
		[WorkstationKey] [int] IDENTITY(1,1) NOT NULL,
		[WorkstationHostName] [nvarchar](250)
	 CONSTRAINT [PK_DimWorkstation] PRIMARY KEY CLUSTERED 
	(
		[WorkstationKey] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]