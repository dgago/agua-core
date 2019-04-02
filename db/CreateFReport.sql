IF NOT EXISTS (SELECT name FROM sys.tables where name = 'F_Report')
	CREATE TABLE [dbo].[F_Report](
		[PoolKey] [int] NOT NULL,
        [ProcedureKey] [int] NOT NULL,
        [AdmissionTypeKey] [int],
        [OpenDateKey] [int] NOT NULL,
        [ClosedDateKey] [int] NOT NULL,
        [PreliminaryDateKey] [int] NOT NULL, 
        [AnnuledDateKey] [int] NOT NULL,
        [OpenTimeKey] [int] NOT NULL,
        [ClosedTimeKey] [int] NOT NULL,
        [PreliminaryTimeKey] [int] NOT NULL,
        [AnnuledTimeKey] [int] NOT NULL,
        [DictatedHealthProfessionalKey] [int] NOT NULL,
        [ApprovedHealthProfessionalKey] [int] NOT NULL,
        [AnnuledHealthProfessionalKey] [int] NOT NULL,
        [PreliminaryHealthProfessionalKey] [int] NOT NULL,
        [Patientkey] [int] NOT NULL,
        [ReportStatusKey] [int] NOT NULL,
        [AddenddumHealthProfessionalKey] [int] NOT NULL,        
		[AddenddumDateKey] [int] NOT NULL,
        [AddenddumTimeKey] [int] NOT NULL,
        [WaitingApprovalHealthProfessionalKey] [int] NOT NULL,
        [WorkstationOpenReportKey] [int] NOT NULL,
        [WorkstationCloseReportKey] [int] NOT NULL,
        [InternalReportId] [int] NOT NULL,
        [AccessionNb] [nvarchar](255),
        [OpenToPreliminaryTime] [int],
        [OpenToFinalizeTime] [int],
        [CompleteToOpenReport] [int],
        [PreliminaryToFinalizeTime] [int],
	 CONSTRAINT [PK_FReport] PRIMARY KEY CLUSTERED 
	(
		[OpenDateKey] ASC, [ClosedDateKey] ASC, [PreliminaryDateKey], [AnnuledDateKey], [PoolKey], [ProcedureKey], [DictatedHealthProfessionalKey] ASC, [ApprovedHealthProfessionalKey] ASC, 
        [OpenTimeKey], [ClosedTimeKey], [PreliminaryTimeKey], [AnnuledTimeKey], [Patientkey] ASC, [ReportStatusKey] ASC, [AddenddumHealthProfessionalKey] ASC, 
        [AddenddumDateKey] ASC, [WaitingApprovalHealthProfessionalKey] ASC, [InternalReportId] ASC, [AnnuledHealthProfessionalKey], [AccessionNb] ASC, [PreliminaryHealthProfessionalKey],
        [AddenddumTimeKey], [AdmissionTypeKey], [WorkstationOpenReportKey], [WorkstationCloseReportKey] 
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]


    