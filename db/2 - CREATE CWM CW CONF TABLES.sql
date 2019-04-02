USE [CWM_BI_CONF]
GO

IF NOT EXISTS (SELECT name FROM sys.tables where name = 'DTSXPackage')
	CREATE TABLE [dbo].[DTSXPackage](
		[PackageId] [int] IDENTITY(1,1) NOT NULL,
		[PackageName] [nvarchar](255),
		[IsActive] [bit],
        [LastExecutionStart] [datetime],
		[ProjectFinishExecution] [datetime],
        [ExecutionTime] [int]
	 CONSTRAINT [PK_DimHealthCenter] PRIMARY KEY CLUSTERED 
	(
		[PackageId] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]
GO