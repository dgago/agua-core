IF NOT EXISTS (SELECT name FROM sys.tables where name = 'DimReportStatus')
	CREATE TABLE [dbo].[DimReportStatus](
		[ReportStatusKey] [int] IDENTITY(1,1) NOT NULL,
		[InternalReportStatus] [int] NOT NULL,
		[ReportStatus] [nvarchar](255)
	 CONSTRAINT [PK_DimReportStatus] PRIMARY KEY CLUSTERED 
	(
		[ReportStatusKey] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]