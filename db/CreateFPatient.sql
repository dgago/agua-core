IF NOT EXISTS (SELECT name FROM sys.tables where name = 'F_Patient')
	CREATE TABLE [dbo].[F_Patient](
        [PatientKey] [int] NOT NULL,        
        [CreatedDateKey] [int],
        [DeceasedDateKey] [int],
        [ArchivedDateKey] [int]        
	 CONSTRAINT [PK_FPatient] PRIMARY KEY CLUSTERED 
	(
		[PatientKey] ASC, [DeceasedDateKey], [CreatedDateKey], [ArchivedDateKey] 
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]


    