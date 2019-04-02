IF NOT EXISTS (SELECT name FROM sys.tables where name = 'DimDate')
	CREATE TABLE [dbo].[DimDate](
        [DateKey] [int] IDENTITY(1,1) NOT NULL,
		[FullDate] [datetime],
		[DayName] [nvarchar](255) NOT NULL,
		[DayOfWeek] [int],
        [DayOfMonth] [int],
        [DayOfYear] [int],
        [WeekOfYear] [int],
		[Month] [int],
        [MonthName] [nvarchar](255) NOT NULL,
        [MonthYearName] [nvarchar](255) NOT NULL,
        [Quarter] [int],
        [QuarterName] [nvarchar](255) NOT NULL,
        [QuarterYearName] [nvarchar](255) NOT NULL,
        [Year] [int],
        [isWeekend] [bit]	
	 CONSTRAINT [PK_DimDate] PRIMARY KEY CLUSTERED 
	(
		[DateKey] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]