USE [tradescope]
GO

/****** Object:  Table [dbo].[tbl_b3_stocks]    Script Date: 16/12/2025 02:10:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tbl_b3_stocks](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[stock] [varchar](10) NOT NULL,
	[name] [varchar](255) NOT NULL,
	[logo] [varchar](255) NOT NULL,
	[sector] [varchar](50) NOT NULL,
	[type] [varchar](20) NOT NULL,
 CONSTRAINT [PK_tbl_b3_stocks] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


