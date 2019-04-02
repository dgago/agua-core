IF NOT EXISTS (SELECT name FROM sys.tables where name = 'DimAdmissionType')
	CREATE TABLE [dbo].[DimAdmissionType](
		[AdmissionTypeKey] [int] IDENTITY(1,1) NOT NULL,
		[AdmissionTypeCode] [nvarchar](10) NOT NULL,
		[AdmissionTypeDescription] [nvarchar](50)
	 CONSTRAINT [PK_DimAdmissionType] PRIMARY KEY CLUSTERED 
	(
		[AdmissionTypeKey] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]