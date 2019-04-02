IF NOT EXISTS (SELECT name FROM sys.tables where name = 'DimHealthProfessional')
	CREATE TABLE [dbo].[DimHealthProfessional](
		[HealthProfessionalKey] [int] IDENTITY(1,1) NOT NULL,
		[PracticeNumber] [nvarchar](50) NOT NULL,
		[FullName] [nvarchar](255),
		[PhoneNumber] [nvarchar](20),
        [FunctionRole] [nvarchar](50),
		[FunctionType] [nvarchar](255)		
	 CONSTRAINT [PK_DimHealthProfessional] PRIMARY KEY CLUSTERED 
	(
		[HealthProfessionalKey] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]