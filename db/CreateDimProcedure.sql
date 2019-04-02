IF NOT EXISTS (SELECT name FROM sys.tables where name = 'DimProcedure')
	CREATE TABLE [dbo].[DimProcedure](
		[ProcedureKey] [int] IDENTITY(1,1) NOT NULL,
		[ProcedureName] [nvarchar](255),
		[DurationMin] [int],
		[BodyPart] [nvarchar](255),
        [ModalityCode] [nvarchar](50) NOT NULL,
		[ModalityName] [nvarchar](50),
        [IsScreening] [bit],
        [IsMamoReport] [bit],
        [IsBiopsy] [bit],
		[NeedContrast] [int],
		[ClinicalAssessmentType] [tinyint] NOT NULL,
        [ClinicalAssessmentTypeName] [nvarchar](100),
		[PreparationTimeminutes] [int] ,
		[ExternalCode] [nvarchar](255) NOT NULL,
		[ExternalName] [nvarchar](255)		
	 CONSTRAINT [PK_DimProcedure] PRIMARY KEY CLUSTERED 
	(
		[ProcedureKey] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]