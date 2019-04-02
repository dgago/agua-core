IF NOT EXISTS (SELECT name FROM sys.tables where name = 'DimExamState')
	CREATE TABLE [dbo].[DimExamState](
		[ExamStateKey] [int] IDENTITY(1,1) NOT NULL,
		[InternalExamStatus] [int] NOT NULL,
		[ExamState] [nvarchar](255) NOT NULL
	 CONSTRAINT [PK_DimExamState] PRIMARY KEY CLUSTERED 
	(
		[ExamStateKey] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]