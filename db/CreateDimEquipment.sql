IF NOT EXISTS (SELECT name FROM sys.tables where name = 'DimEquipment')
	CREATE TABLE [dbo].[DimEquipment](
		[EquipmentKey] [int] IDENTITY(1,1) NOT NULL,
		[InternalNumber] [int] NOT NULL,
		[Designation] [nvarchar](50),
		[InternalDesignation] [nvarchar](50),
		[AeTitle] [nvarchar](50),
        [Brand] [nvarchar](50),
		[ModalityCode] [nvarchar](50) NOT NULL,
		[ModalityName] [nvarchar](50),
		[LocationCode] [nvarchar](255) NOT NULL,
		[LocationName] [nvarchar](255)		
	 CONSTRAINT [PK_DimEquipment] PRIMARY KEY CLUSTERED 
	(
		[EquipmentKey] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]