USE [tradescope]
GO

/****** Object:  Table [dbo].[tbl_b3_indexes]    Script Date: 16/12/2025 02:29:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tbl_indexes](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[stock] [nvarchar](50) NOT NULL,
	[name] [nvarchar](525) NOT NULL,
 CONSTRAINT [PK_tbl_indexes] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


