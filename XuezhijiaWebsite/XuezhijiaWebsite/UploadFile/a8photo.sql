USE [ChiHuo]
GO

/****** Object:  Table [dbo].[Photo]    Script Date: 08/07/2011 23:33:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Photo](
	[PhotoId] [bigint] IDENTITY(1,1) NOT NULL,
	[PhotoName] [nvarchar](50) NULL,
	[PhotoFile] [image] NULL,
	[PhotoRemark] [nvarchar](50) NULL,
	[PhotoOwnerId] [bigint] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO


