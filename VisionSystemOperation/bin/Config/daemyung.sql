USE [HMMI_VISION]
CREATE TABLE [dbo].[InspectionResults](
	[InspectionResultID] [int] IDENTITY(1,1) NOT NULL,
	[TactTime] [datetime] NOT NULL,
	[CameraNum] [int] NOT NULL,
	[ImgPath] [varchar](500) NOT NULL,
	[Average] [float] NOT NULL,
	[VinID] [varchar](500) NOT NULL,
	[CarName] [varchar](500) NOT NULL,
	[Result] [varchar](500) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[LastModifyDate] [datetime] NOT NULL,
 CONSTRAINT [PK_InspectionResults] PRIMARY KEY CLUSTERED 
(
	[InspectionResultID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


CREATE TABLE [dbo].[ROIResults](
	[ROIResultID] [int] IDENTITY(1,1) NOT NULL,
	[InspectionResultID] [int] NOT NULL,
	[Score] [float] NOT NULL,
	[RoiName] [varchar](500) NOT NULL,
	[Result] [varchar](500) NOT NULL,
	[TrainRectangleX] [int] NOT NULL,
	[TrainRectangleY] [int] NOT NULL,
	[TrainRectangleHeight] [int] NOT NULL,
	[TrainRectangleWidth] [int] NOT NULL,
 CONSTRAINT [PK_ROIResults] PRIMARY KEY CLUSTERED 
(
	[ROIResultID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


CREATE TABLE [dbo].[InspectionNGResults](
	[InspectionNGResultID] [int] IDENTITY(1,1) NOT NULL,
	[InspectionResultID] [int] NOT NULL,
	[ROIResultID] [int] NOT NULL,
 CONSTRAINT [PK_InspectionNGResults] PRIMARY KEY CLUSTERED 
(
	[InspectionNGResultID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

