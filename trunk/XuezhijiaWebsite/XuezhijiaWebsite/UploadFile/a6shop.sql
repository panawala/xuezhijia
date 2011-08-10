USE [ChiHuo]
GO

/****** Object:  Table [dbo].[Shop]    Script Date: 08/07/2011 23:34:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Shop](
	[ShopId] [bigint] IDENTITY(1,1) NOT NULL,
	[ShopName] [nvarchar](50) NULL,
	[ShopContactWay] [nvarchar](50) NULL,
	[ShopContact] [nvarchar](50) NULL,
	[ShopAddress] [nvarchar](200) NULL,
	[ShopScore] [float] NULL,
	[ShopDistrictId] [bigint] NULL,
	[ShopClickedCount] [bigint] NULL
) ON [PRIMARY]

GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'店名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shop', @level2type=N'COLUMN',@level2name=N'ShopName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'联系方式' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shop', @level2type=N'COLUMN',@level2name=N'ShopContactWay'
GO


