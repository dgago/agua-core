IF NOT EXISTS (SELECT name FROM sys.tables where name = 'DimTime')
	CREATE TABLE [dbo].[DimTime](
		[TimeKey] [int] IDENTITY(1,1) NOT NULL,
		[FullTime] [nvarchar](255),
		[Hour] [int],
		[Minute] [int],
        [Minute_Text] [nvarchar](255),
        [Hour_Text] [nvarchar](255),
        [PeriodDay] [nvarchar](255),
        [IsWorkingHours] [bit]	
	 CONSTRAINT [PK_DimTime] PRIMARY KEY CLUSTERED 
	(
		[TimeKey] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]
