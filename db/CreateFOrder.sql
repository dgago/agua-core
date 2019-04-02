IF NOT EXISTS (SELECT name FROM sys.tables where name = 'F_Order')
	CREATE TABLE [dbo].[F_Order](
		[DepartmentKey] [int] NOT NULL,
        [HealthCenterKey] [int] NOT NULL,
        [ReferringPhysicianKey] [int] NOT NULL,
        [OrderPhysicianKey] [int] NOT NULL,
        [PerformingLocationKey] [int] NOT NULL,
        [AdmissionTypeKey] [int],
        [PatientKey] [int] NOT NULL,
        [PoolKey] [int] NOT NULL,
        [ProcedureKey] [int] NOT NULL,
        [OrderStatusKey] [int] NOT NULL,
        [VettingStatusKey] [int] NOT NULL,
        [ScheduleHealthProfessionalKey] [int] NOT NULL,        
		[VettedHealthProfessionalKey] [int] NOT NULL,
        [OrderTimeKey] [int] NOT NULL,
        [VettedTimeKey] [int] NOT NULL,
        [ScheduledTimeKey] [int] NOT NULL,
        [AppointmentTimeKey] [int] NOT NULL,
        [OrderDateKey] [int] NOT NULL,
        [VettedDateKey] [int] NOT NULL,
        [ScheduledDateKey] [int] NOT NULL,
        [AppointmentDateKey] [int] NOT NULL,
        [CancelDateKey] [int] NOT NULL,
        [CancelTimeKey] [int] NOT NULL,
        [TransferDateKey] [int] NOT NULL,
        [TransferTimeKey] [int] NOT NULL,
        [TransferHealthProfessionalKey] [int] NOT NULL,
        [TransferDestKey] [int] NOT NULL,
        [TransferSourceKey] [int] NOT NULL,
        [ExternalOrderId] [nvarchar] (255),
        [InternalOrderId] [int],
        [WaitTimeToApprove] [int],
        [WaitTimeToSchedule] [int],
        [WaitTimeToAppointment] [int],
        [VettingToScheduleTime] [int],
	 CONSTRAINT [PK_FOrder] PRIMARY KEY CLUSTERED 
	(
		[DepartmentKey] ASC, [HealthCenterKey], [ReferringPhysicianKey], [OrderPhysicianKey], [PerformingLocationKey], [PatientKey], [ProcedureKey] ASC, [PoolKey] ASC, [OrderStatusKey] ASC,
        [VettingStatusKey] ASC, [ScheduleHealthProfessionalKey] ASC, [VettedHealthProfessionalKey] ASC, [OrderDateKey] ASC, [VettedDateKey] ASC,
        [ScheduledDateKey] ASC, [AppointmentDateKey] ASC, [OrderTimeKey] ASC, [VettedTimeKey] ASC, [ScheduledTimeKey] ASC, [AppointmentTimeKey] ASC,
        [CancelDateKey] ASC, [CancelTimeKey] ASC, [TransferDestKey] ASC, [TransferTimeKey] ASC, [TransferHealthProfessionalKey], [TransferDateKey] ASC, [TransferSourceKey],
        [ExternalOrderId] ASC, [InternalOrderId] ASC, [AdmissionTypeKey]
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]


    