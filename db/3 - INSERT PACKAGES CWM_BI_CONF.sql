USE [CWM_BI_CONF]
GO

IF NOT EXISTS (SELECT * FROM CWM_BI_CONF.dbo.DTSXPackage WHERE [PackageName] = 'OrderDataMart.dtsx')
	INSERT INTO [dbo].[DTSXPackage]
			   ([PackageName]
			   ,[IsActive]
			   ,[LastExecutionStart]
                     ,[ProjectFinishExecution]
			   ,[ExecutionTime])
		 VALUES
			   ('OrderDataMart.dtsx'
			   ,0
			   ,NULL
                     ,NULL
			   ,NULL)

IF NOT EXISTS (SELECT * FROM CWM_BI_CONF.dbo.DTSXPackage WHERE [PackageName] = 'PatientDataMart.dtsx')
INSERT INTO [dbo].[DTSXPackage]
           ([PackageName]
           ,[IsActive]
           ,[LastExecutionStart]
           ,[ProjectFinishExecution]
           ,[ExecutionTime])
     VALUES
           ('PatientDataMart.dtsx'
           ,0
           ,NULL
           ,NULL
           ,NULL)

IF NOT EXISTS (SELECT * FROM CWM_BI_CONF.dbo.DTSXPackage WHERE [PackageName] = 'ExamDataMart.dtsx')
INSERT INTO [dbo].[DTSXPackage]
           ([PackageName]
           ,[IsActive]
           ,[LastExecutionStart]
           ,[ProjectFinishExecution]
           ,[ExecutionTime])
     VALUES
           ('ExamDataMart.dtsx'
           ,0
           ,NULL
           ,NULL
           ,NULL)

IF NOT EXISTS (SELECT * FROM CWM_BI_CONF.dbo.DTSXPackage WHERE [PackageName] = 'ReportDataMart.dtsx')
INSERT INTO [dbo].[DTSXPackage]
           ([PackageName]
           ,[IsActive]
           ,[LastExecutionStart]
           ,[ProjectFinishExecution]
           ,[ExecutionTime])
     VALUES
           ('ReportDataMart.dtsx'
           ,0
           ,NULL
           ,NULL
           ,NULL)
GO

