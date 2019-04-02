IF NOT EXISTS (SELECT name FROM sys.tables where name = 'DimTransferDestination')
	CREATE TABLE [dbo].[DimTransferDestination](
		[TransferDestinationKey] [int] IDENTITY(1,1) NOT NULL,
		[CodeDestination] [nvarchar](50)  NOT NULL,
		[DestinationName] [nvarchar](255)
	 CONSTRAINT [PK_DimTransferDestination] PRIMARY KEY CLUSTERED 
	(
		[TransferDestinationKey] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]