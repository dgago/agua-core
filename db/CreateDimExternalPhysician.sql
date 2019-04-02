IF NOT EXISTS (SELECT name FROM sys.tables where name = 'DimExternalPhysician')
	CREATE TABLE [dbo].[DimExternalPhysician](
		[ExternalPhysicianKey] [int] IDENTITY(1,1) NOT NULL,
		[ExternalPhysicianName] [nvarchar](255) NOT NULL,
		[ExternalPhysicianCode] [nvarchar](255),
        [PhoneNumber] [nvarchar](255)
	 CONSTRAINT [PK_DimExternalPhysician] PRIMARY KEY CLUSTERED 
	(
		[ExternalPhysicianKey] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]