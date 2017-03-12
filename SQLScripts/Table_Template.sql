USE [FINCONTROL]
GO

/****** Object:  Table [dbo].[Table_Template]    Script Date: 12.03.2017 12:08:02 ******/
DROP TABLE [dbo].[Table_Template]
GO

/****** Object:  Table [dbo].[Table_Template]    Script Date: 12.03.2017 12:08:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Table_Template](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Nvarchar] [nvarchar](100) NOT NULL,
	[Date] [date] NOT NULL,
	[Decimal] [decimal](18, 2) NOT NULL,
	[Boolean] [bit] NOT NULL,
	[Int] [int] NOT NULL,
	[DateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_Table_Template] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


