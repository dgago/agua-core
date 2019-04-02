IF NOT EXISTS (SELECT name FROM sys.tables where name = 'DimPatient')
	CREATE TABLE [dbo].[DimPatient](
		[PatientKey] [int] IDENTITY(1,1) NOT NULL,
		[PatientId] [nvarchar](50) NOT NULL,
		[FullName] [nvarchar](300),
		[Age] [int],
        [DateOfBirth] [datetime],
		[Gender] [nvarchar](10),
        [Nationality] [nvarchar](50),
		[Addres] [nvarchar](255),
		[City] [nvarchar](255),
		[PhoneNumber] [nvarchar](50),
		[MobileNumber] [nvarchar](50),
		[UpdatedDate] [datetime]
	 CONSTRAINT [PK_DimPatient] PRIMARY KEY CLUSTERED 
	(
		[PatientKey] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]