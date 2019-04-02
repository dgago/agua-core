IF NOT EXISTS (SELECT name FROM sys.tables where name = 'F_Equipment')
	CREATE TABLE [dbo].[F_Equipment](
        [EquipmentKey] [int] NOT NULL,        
        [DateKey] [int]  NOT NULL,
        [StartTimeKey] [int]  NOT NULL,
        [EndTimeKey] [int]  NOT NULL,
        [TotalSchedules] [int],
        [TotalSlots] [int],
        [RemainingSlots] [int]        
	 CONSTRAINT [PK_FEquipment] PRIMARY KEY CLUSTERED 
	(
		[EquipmentKey] ASC, [DateKey] ASC, [StartTimeKey] ASC, [EndTimeKey] ASC 
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]


    