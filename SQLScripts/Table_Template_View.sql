USE [FINCONTROL]
GO

/****** Object:  StoredProcedure [dbo].[sp_Table_Template_View]    Script Date: 12.03.2017 12:11:36 ******/
DROP PROCEDURE [dbo].[sp_Table_Template_View]
GO

/****** Object:  StoredProcedure [dbo].[sp_Table_Template_View]    Script Date: 12.03.2017 12:11:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


Create  PROCEDURE [dbo].[sp_Table_Template_View] as

SELECT [ID]
      ,[Nvarchar]
      ,[Date]
      ,[Decimal]
      ,[Boolean]
      ,[Int]
      ,[DateTime]
  FROM [dbo].[Table_Template]

GO


