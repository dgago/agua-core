IF NOT EXISTS (SELECT name FROM sys.tables where name = 'DimDepartment')
	CREATE TABLE [dbo].[DimDepartment](
		[DepartmentKey] [int] IDENTITY(1,1) NOT NULL,
		[DepartmentName] [nvarchar](255),
		[DepartmentCode] [nvarchar](255),
        [LocationName] [nvarchar](255),
		[LocationCode] [nvarchar](255),
        [PhoneNumber] [nvarchar](255)
	 CONSTRAINT [PK_DimDepartment] PRIMARY KEY CLUSTERED 
	(
		[DepartmentKey] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]